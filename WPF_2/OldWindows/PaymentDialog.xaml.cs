using System;
using System.Windows;

namespace WPF_2
{
    public partial class PaymentDialog : Window
    {
        public int PaymentId { get; set; }

        public PaymentDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            PaymentId = Convert.ToInt32(PaymentIdTextBox.Text);
            this.DialogResult = true;
        }
    }
}