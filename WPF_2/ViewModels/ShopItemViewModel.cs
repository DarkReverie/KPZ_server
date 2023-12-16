using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using DS_Lab_3.Models;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;

namespace WPF_2.ViewModels
{
    public class ShopItemViewModel
    {
        public ObservableCollection<Shopitem>? ShopItems { get; set; }
        public int SelectedShopItemId { get; set; }
        public RelayCommand GetCommand { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5110/api/Shopitem"; // Update the URL to match your API endpoint

        public ShopItemViewModel()
        {
            _httpClient = new HttpClient();
            ShopItems = new ObservableCollection<Shopitem>();
            GetCommand = new RelayCommand(GetShopItems);
            AddCommand = new RelayCommand(AddShopItem);
            DeleteCommand = new RelayCommand(DeleteShopItem);
            UpdateCommand = new RelayCommand(UpdateShopItem);
        }

        public async void GetShopItems()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var shopItems = JsonConvert.DeserializeObject<IEnumerable<Shopitem>>(content);
                ShopItems.Clear();
                foreach (var shopItem in shopItems)
                {
                    ShopItems.Add(shopItem);
                }
            }
        }

        private async void AddShopItem()
        {
            var detailsWindow = new ShopItemDetailsWindow { ShopItem = new Shopitem() };
            if (detailsWindow.ShowDialog() == true)
            {
                var shopItem = detailsWindow.ShopItem;
                var json = JsonConvert.SerializeObject(shopItem);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(BaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var addedShopItem = JsonConvert.DeserializeObject<Shopitem>(await response.Content.ReadAsStringAsync());
                    ShopItems.Add(addedShopItem);
                }
            }
        }

        private async void DeleteShopItem()
        {
            if (SelectedShopItemId <= 0) return;

            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{SelectedShopItemId}");
            if (response.IsSuccessStatusCode)
            {
                var shopItemToDelete = ShopItems.FirstOrDefault(item => item.Id == SelectedShopItemId);
                if (shopItemToDelete != null)
                {
                    ShopItems.Remove(shopItemToDelete);
                }
            }
        }

        private async void UpdateShopItem()
        {
            var selectedShopItem = ShopItems.FirstOrDefault(item => item.Id == SelectedShopItemId);
            if (selectedShopItem != null)
            {
                var detailsWindow = new ShopItemDetailsWindow { ShopItem = selectedShopItem };
                if (detailsWindow.ShowDialog() == true)
                {
                    var updatedShopItem = detailsWindow.ShopItem;
                    var json = JsonConvert.SerializeObject(updatedShopItem);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync($"{BaseUrl}/{updatedShopItem.Id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        ShopItems.Remove(selectedShopItem);
                        var itemFromResponse = JsonConvert.DeserializeObject<Shopitem>(await response.Content.ReadAsStringAsync());
                        ShopItems.Add(itemFromResponse);
                    }
                }
            }
        }
    }
}
