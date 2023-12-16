

using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using DS_Lab_3.Models;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;

namespace WPF_2.ViewModels
{
    public class LockerViewModel
    {
        public ObservableCollection<Locker>? Lockers { get; set; }
        public int SelectedLockerId { get; set; }
        public RelayCommand GetCommand { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5110/api/Locker"; // Update the URL to match your API endpoint

        public LockerViewModel()
        {
            _httpClient = new HttpClient();
            Lockers = new ObservableCollection<Locker>();
            GetCommand = new RelayCommand(GetLockers);
            AddCommand = new RelayCommand(AddLocker);
            DeleteCommand = new RelayCommand(DeleteLocker);
            UpdateCommand = new RelayCommand(UpdateLocker);
        }

        public async void GetLockers()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var lockers = JsonConvert.DeserializeObject<IEnumerable<Locker>>(content);
                Lockers.Clear();
                foreach (var locker in lockers)
                {
                    Lockers.Add(locker);
                }
            }
        }

        private async void AddLocker()
        {
            var detailsWindow = new LockerDetailsWindow { Locker = new Locker() };
            if (detailsWindow.ShowDialog() == true)
            {
                var locker = detailsWindow.Locker;
                var json = JsonConvert.SerializeObject(locker);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(BaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var addedLocker = JsonConvert.DeserializeObject<Locker>(await response.Content.ReadAsStringAsync());
                    Lockers.Add(addedLocker);
                }
            }
        }

        private async void DeleteLocker()
        {
            if (SelectedLockerId <= 0) return;

            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{SelectedLockerId}");
            if (response.IsSuccessStatusCode)
            {
                var lockerToDelete = Lockers.FirstOrDefault(l => l.Id == SelectedLockerId);
                if (lockerToDelete != null)
                {
                    Lockers.Remove(lockerToDelete);
                }
            }
        }

        private async void UpdateLocker()
        {
            var selectedLocker = Lockers.FirstOrDefault(l => l.Id == SelectedLockerId);
            if (selectedLocker != null)
            {
                var detailsWindow = new LockerDetailsWindow { Locker = selectedLocker };
                if (detailsWindow.ShowDialog() == true)
                {
                    var updatedLocker = detailsWindow.Locker;
                    var json = JsonConvert.SerializeObject(updatedLocker);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync($"{BaseUrl}/{updatedLocker.Id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        Lockers.Remove(selectedLocker);
                        var lockerFromResponse = JsonConvert.DeserializeObject<Locker>(await response.Content.ReadAsStringAsync());
                        Lockers.Add(lockerFromResponse);
                    }
                }
            }
        }
    }
}
