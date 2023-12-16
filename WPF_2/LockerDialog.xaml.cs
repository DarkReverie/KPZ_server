using System;
using System.Windows;

namespace WPF_2
{
    public partial class LockerDialog : Window
    {
        public int LockerId { get; set; }

        public LockerDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            LockerId = Convert.ToInt32(LockerIdTextBox.Text);
            this.DialogResult = true;
        }
    }
}