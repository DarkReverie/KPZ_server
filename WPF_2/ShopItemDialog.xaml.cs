using System;
using System.Windows;

namespace WPF_2
{
    public partial class ShopItemDialog : Window
    {
        public int ShopItemId { get; set; }

        public ShopItemDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ShopItemId= Convert.ToInt32(ShopItemIdTextBox.Text);
            this.DialogResult = true;
        }
    }
}