using System.Windows;

namespace WPF_2;

using System.Windows;
using DS_Lab_3.Models;


public partial class InvoiceDetailsWindow : Window
{
    public static readonly DependencyProperty InvoiceProperty = DependencyProperty.Register(
        "Invoice", typeof(Invoice), typeof(InvoiceDetailsWindow), new PropertyMetadata(null));

    public Invoice Invoice
    {
        get { return (Invoice)GetValue(InvoiceProperty); }
        set { SetValue(InvoiceProperty, value); }
    }

    public InvoiceDetailsWindow()
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