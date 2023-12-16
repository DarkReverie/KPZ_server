using System.Windows;
using System.Windows.Controls;
using DS_Lab_3.Models;

namespace WPF_2.Controls
{
    public partial class ShopItemControl : UserControl
    {
        public static readonly DependencyProperty ShopItemProperty = DependencyProperty.Register(
            "ShopItem", typeof(Shopitem), typeof(ShopItemControl), new PropertyMetadata(null));

        public Shopitem ShopItem
        {
            get { return (Shopitem)GetValue(ShopItemProperty); }
            set { SetValue(ShopItemProperty, value); }
        }

        public ShopItemControl()
        {
            InitializeComponent();
        }
    }
}