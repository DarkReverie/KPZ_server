using System.Windows;
using DS_Lab_3.Models;

namespace WPF_2;

public partial class PaymentDetailsWindow : Window
{
    public static readonly DependencyProperty PaymentProperty = DependencyProperty.Register(
        "Payment", typeof(Payment), typeof(PaymentDetailsWindow), new PropertyMetadata(null));

    public Payment Payment
    {
        get { return (Payment)GetValue(PaymentProperty); }
        set { SetValue(PaymentProperty, value); }
    }

    public PaymentDetailsWindow()
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