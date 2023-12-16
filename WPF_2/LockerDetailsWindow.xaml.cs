using System.Windows;
using DS_Lab_3.Models;

namespace WPF_2
{
    public partial class LockerDetailsWindow : Window
    {
        public static readonly DependencyProperty LockerProperty = DependencyProperty.Register(
            "Locker", typeof(Locker), typeof(LockerDetailsWindow), new PropertyMetadata(null));

        public Locker Locker
        {
            get { return (Locker)GetValue(LockerProperty); }
            set { SetValue(LockerProperty, value); }
        }

        public LockerDetailsWindow()
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