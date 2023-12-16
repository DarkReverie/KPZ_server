using System.Windows;
using DS_Lab_3.Models;

namespace WPF_2;

public partial class MembershipDetailsWindow : Window
{
    public static readonly DependencyProperty MembershipProperty = DependencyProperty.Register(
        "Membership", typeof(Membership), typeof(MembershipDetailsWindow), new PropertyMetadata(null));

    public Membership Membership
    {
        get { return (Membership)GetValue(MembershipProperty); }
        set { SetValue(MembershipProperty, value); }
    }

    public MembershipDetailsWindow()
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