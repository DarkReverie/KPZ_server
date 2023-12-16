


using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using DS_Lab_3.Models;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;


namespace WPF_2.ViewModels
{
    public class InvoiceViewModel
    {
        public ObservableCollection<Invoice>? Invoices { get; set; }
        public int SelectedInvoiceId { get; set; }
        public RelayCommand GetCommand { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5110/api/Invoice"; // Update the URL to match your API endpoint

        public InvoiceViewModel()
        {
            _httpClient = new HttpClient();
            Invoices = new ObservableCollection<Invoice>();
            GetCommand = new RelayCommand(GetInvoices);
            AddCommand = new RelayCommand(AddInvoice);
            DeleteCommand = new RelayCommand(DeleteInvoice);
            UpdateCommand = new RelayCommand(UpdateInvoice);
        }

        public async void GetInvoices()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var invoices = JsonConvert.DeserializeObject<IEnumerable<Invoice>>(content);
                Invoices.Clear();
                foreach (var invoice in invoices)
                {
                    Invoices.Add(invoice);
                }
            }
        }

        private async void AddInvoice()
        {
            var detailsWindow = new InvoiceDetailsWindow { Invoice = new Invoice() };
            if (detailsWindow.ShowDialog() == true)
            {
                var invoice = detailsWindow.Invoice;
                var json = JsonConvert.SerializeObject(invoice);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(BaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var addedInvoice = JsonConvert.DeserializeObject<Invoice>(await response.Content.ReadAsStringAsync());
                    Invoices.Add(addedInvoice);
                }
            }
        }

        private async void DeleteInvoice()
        {
            if (SelectedInvoiceId <= 0) return;

            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{SelectedInvoiceId}");
            if (response.IsSuccessStatusCode)
            {
                var invoiceToDelete = Invoices.FirstOrDefault(i => i.Id == SelectedInvoiceId);
                if (invoiceToDelete != null)
                {
                    Invoices.Remove(invoiceToDelete);
                }
            }
        }

        private async void UpdateInvoice()
        {
            var selectedInvoice = Invoices.FirstOrDefault(i => i.Id == SelectedInvoiceId);
            if (selectedInvoice != null)
            {
                var detailsWindow = new InvoiceDetailsWindow { Invoice = selectedInvoice };
                if (detailsWindow.ShowDialog() == true)
                {
                    var updatedInvoice = detailsWindow.Invoice;
                    var json = JsonConvert.SerializeObject(updatedInvoice);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync($"{BaseUrl}/{updatedInvoice.Id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        Invoices.Remove(selectedInvoice);
                        var invoiceFromResponse = JsonConvert.DeserializeObject<Invoice>(await response.Content.ReadAsStringAsync());
                        Invoices.Add(invoiceFromResponse);
                    }
                }
            }
        }
    }
}
