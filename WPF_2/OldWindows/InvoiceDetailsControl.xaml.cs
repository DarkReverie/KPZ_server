using System.Windows;
using System.Windows.Controls;
using DS_Lab_3.Models;

namespace WPF_2.Controls;

public partial class InvoiceDetailsControl : UserControl
{
    public static readonly DependencyProperty InvoiceProperty = DependencyProperty.Register(
        "Invoice", typeof(Invoice), typeof(InvoiceDetailsControl), new PropertyMetadata(null));

    public Invoice Invoice
    {
        get { return (Invoice)GetValue(InvoiceProperty); }
        set { SetValue(InvoiceProperty, value); }
    }

    public InvoiceDetailsControl()
    {
        InitializeComponent();
    }
}
