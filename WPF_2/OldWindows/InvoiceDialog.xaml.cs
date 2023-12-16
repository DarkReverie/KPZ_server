using System;
using System.Windows;

namespace WPF_2
{
    public partial class InvoiceDialog : Window
    {
        public int InvoiceId { get; set; }

        public InvoiceDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            InvoiceId = Convert.ToInt32(InvoiceIdTextBox.Text);
            this.DialogResult = true;
        }
    }
}