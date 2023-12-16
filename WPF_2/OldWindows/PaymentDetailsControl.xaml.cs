using System.Windows;
using System.Windows.Controls;
using DS_Lab_3.Models;

namespace WPF_2.Controls;

public partial class PaymentDetailsControl : UserControl
{
    public static readonly DependencyProperty PaymentProperty = DependencyProperty.Register(
        "Payment", typeof(Payment), typeof(PaymentDetailsControl), new PropertyMetadata(null));

    public Payment Payment
    {
        get { return (Payment)GetValue(PaymentProperty); }
        set { SetValue(PaymentProperty, value); }
    }

    public PaymentDetailsControl()
    {
        InitializeComponent();
    }
}