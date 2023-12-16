using System.Windows;
using System.Windows.Controls;
using DS_Lab_3.Models;

namespace WPF_2.Controls;

public partial class MembershipDetailsControl : UserControl
{
    public static readonly DependencyProperty MembershipProperty = DependencyProperty.Register(
        "Membership", typeof(Membership), typeof(MembershipDetailsControl), new PropertyMetadata(null));

    public Membership Membership
    {
        get { return (Membership)GetValue(MembershipProperty); }
        set { SetValue(MembershipProperty, value); }
    }

    public MembershipDetailsControl()
    {
        InitializeComponent();
    }
}