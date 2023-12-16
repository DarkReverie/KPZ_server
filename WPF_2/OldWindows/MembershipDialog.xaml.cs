using System;
using System.Windows;

namespace WPF_2
{
    public partial class MembershipDialog : Window
    {
        public int MemberId { get; set; }

        public MembershipDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            MemberId = Convert.ToInt32(MemberIdTextBox.Text);
            this.DialogResult = true;
        }
    }
}