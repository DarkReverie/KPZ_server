using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using DS_Lab_3.Models;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;



namespace WPF_2.ViewModels
{
    public class MembershipViewModel
    {
        public ObservableCollection<Membership>? Memberships { get; set; }
        public int SelectedMembershipId { get; set; }
        public RelayCommand GetCommand { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5110/api/Membership"; // Update the URL to match your API endpoint

        public MembershipViewModel()
        {
            _httpClient = new HttpClient();
            Memberships = new ObservableCollection<Membership>();
            GetCommand = new RelayCommand(GetMemberships);
            AddCommand = new RelayCommand(AddMembership);
            DeleteCommand = new RelayCommand(DeleteMembership);
            UpdateCommand = new RelayCommand(UpdateMembership);
        }

        public async void GetMemberships()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var memberships = JsonConvert.DeserializeObject<IEnumerable<Membership>>(content);
                Memberships.Clear();
                foreach (var membership in memberships)
                {
                    Memberships.Add(membership);
                }
            }
        }

        private async void AddMembership()
        {
            var detailsWindow = new MembershipDetailsWindow { Membership = new Membership() };
            if (detailsWindow.ShowDialog() == true)
            {
                var membership = detailsWindow.Membership;
                var json = JsonConvert.SerializeObject(membership);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(BaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var addedMembership = JsonConvert.DeserializeObject<Membership>(await response.Content.ReadAsStringAsync());
                    Memberships.Add(addedMembership);
                }
            }
        }

        private async void DeleteMembership()
        {
            if (SelectedMembershipId <= 0) return;

            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{SelectedMembershipId}");
            if (response.IsSuccessStatusCode)
            {
                var membershipToDelete = Memberships.FirstOrDefault(m => m.Id == SelectedMembershipId);
                if (membershipToDelete != null)
                {
                    Memberships.Remove(membershipToDelete);
                }
            }
        }

        private async void UpdateMembership()
        {
            var selectedMembership = Memberships.FirstOrDefault(m => m.Id == SelectedMembershipId);
            if (selectedMembership != null)
            {
                var detailsWindow = new MembershipDetailsWindow { Membership = selectedMembership };
                if (detailsWindow.ShowDialog() == true)
                {
                    var updatedMembership = detailsWindow.Membership;
                    var json = JsonConvert.SerializeObject(updatedMembership);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync($"{BaseUrl}/{updatedMembership.Id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        Memberships.Remove(selectedMembership);
                        var membershipFromResponse = JsonConvert.DeserializeObject<Membership>(await response.Content.ReadAsStringAsync());
                        Memberships.Add(membershipFromResponse);
                    }
                }
            }
        }
    }
}
