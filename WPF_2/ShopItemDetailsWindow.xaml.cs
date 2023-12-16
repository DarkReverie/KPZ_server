using System.Windows;
using DS_Lab_3.Models;

namespace WPF_2
{
    public partial class ShopItemDetailsWindow : Window
    {
        public static readonly DependencyProperty ShopItemProperty = DependencyProperty.Register(
            "ShopItem", typeof(Shopitem), typeof(ShopItemDetailsWindow), new PropertyMetadata(null));

        public Shopitem ShopItem
        {
            get { return (Shopitem)GetValue(ShopItemProperty); }
            set { SetValue(ShopItemProperty, value); }
        }

        public ShopItemDetailsWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}