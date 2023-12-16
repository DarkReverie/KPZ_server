using System.Windows;
using WPF_2.ViewModels;

namespace WPF_2
{
    public partial class MainWindow : Window
    {

        private LockerViewModel _lockerViewModel;
        private ShopItemViewModel _shopItemViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _lockerViewModel = new LockerViewModel();
            _shopItemViewModel = new ShopItemViewModel();
            

            LockerDataGrid.ItemsSource = _lockerViewModel.Lockers;
            _lockerViewModel.GetCommand.Execute(null);

            ShopItemDataGrid.ItemsSource = _shopItemViewModel.ShopItems;
            _shopItemViewModel.GetCommand.Execute(null);
        }

        
        private void AddLockerButton_Click(object sender, RoutedEventArgs e)
        {
            _lockerViewModel.AddCommand.Execute(null);
        }

        private void DeleteLockerButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new LockerDialog();
            if (dialog.ShowDialog() == true)
            {
                _lockerViewModel.SelectedLockerId = dialog.LockerId;
                _lockerViewModel.DeleteCommand.Execute(null);
            }
        }


        private void UpdateLockerButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new LockerDialog();
            if (dialog.ShowDialog() == true)
            {
                _lockerViewModel.SelectedLockerId = dialog.LockerId;
                _lockerViewModel.UpdateCommand.Execute(null);
            }
        }

        private void AddShopItemButton_Click(object sender, RoutedEventArgs e)
        {
            _shopItemViewModel.AddCommand.Execute(null);
        }

        private void DeleteShopItemButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ShopItemDialog();
            if (dialog.ShowDialog() == true)
            {
                _shopItemViewModel.SelectedShopItemId = dialog.ShopItemId;
                _shopItemViewModel.DeleteCommand.Execute(null);
            }
        }

        private void UpdateShopItemButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ShopItemDialog();
            if (dialog.ShowDialog() == true)
            {
                _shopItemViewModel.SelectedShopItemId = dialog.ShopItemId;
                _shopItemViewModel.UpdateCommand.Execute(null);
            }
        }
    }
    
}
