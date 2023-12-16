using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using DS_Lab_3.Models;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;

// Update the namespace to match your project

namespace WPF_2.ViewModels
{
    public class PaymentViewModel
    {
        public ObservableCollection<Payment>? Payments { get; set; }
        public int SelectedPaymentId { get; set; }
        public RelayCommand GetCommand { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5110/api/Payment"; // Update the URL to match your API endpoint

        public PaymentViewModel()
        {
            _httpClient = new HttpClient();
            Payments = new ObservableCollection<Payment>();
            GetCommand = new RelayCommand(GetPayments);
            AddCommand = new RelayCommand(AddPayment);
            DeleteCommand = new RelayCommand(DeletePayment);
            UpdateCommand = new RelayCommand(UpdatePayment);
        }

        public async void GetPayments()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var payments = JsonConvert.DeserializeObject<IEnumerable<Payment>>(content);
                Payments.Clear();
                foreach (var payment in payments)
                {
                    Payments.Add(payment);
                }
            }
        }

        private async void AddPayment()
        {
            var detailsWindow = new PaymentDetailsWindow { Payment = new Payment() };
            if (detailsWindow.ShowDialog() == true)
            {
                var payment = detailsWindow.Payment;

                var serializerSettings = new JsonSerializerSettings
                {
                    DateFormatString = "yyyy-MM-dd"
                };

                var json = JsonConvert.SerializeObject(payment, serializerSettings);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(BaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var addedPayment = JsonConvert.DeserializeObject<Payment>(await response.Content.ReadAsStringAsync());
                    Payments.Add(addedPayment);
                }
            }
        }

        private async void DeletePayment()
        {
            if (SelectedPaymentId <= 0) return;

            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{SelectedPaymentId}");
            if (response.IsSuccessStatusCode)
            {
                var paymentToDelete = Payments.FirstOrDefault(p => p.Id == SelectedPaymentId);
                if (paymentToDelete != null)
                {
                    Payments.Remove(paymentToDelete);
                }
            }
        }

        private async void UpdatePayment()
        {
            var selectedPayment = Payments.FirstOrDefault(p => p.Id == SelectedPaymentId);
            if (selectedPayment != null)
            {
                var detailsWindow = new PaymentDetailsWindow { Payment = selectedPayment };
                if (detailsWindow.ShowDialog() == true)
                {
                    var updatedPayment = detailsWindow.Payment;
                    var json = JsonConvert.SerializeObject(updatedPayment);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync($"{BaseUrl}/{updatedPayment.Id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        Payments.Remove(selectedPayment);
                        var paymentFromResponse = JsonConvert.DeserializeObject<Payment>(await response.Content.ReadAsStringAsync());
                        Payments.Add(paymentFromResponse);
                    }
                }
            }
        }
    }
}
