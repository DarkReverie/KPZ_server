using System.Windows;
using System.Windows.Controls;
using DS_Lab_3.Models;

namespace WPF_2.Controls
{
    public partial class LockerDetailsControl : UserControl
    {
        public static readonly DependencyProperty LockerProperty = DependencyProperty.Register(
            "Locker", typeof(Locker), typeof(LockerDetailsControl), new PropertyMetadata(null));

        public Locker Locker
        {
            get { return (Locker)GetValue(LockerProperty); }
            set { SetValue(LockerProperty, value); }
        }

        public LockerDetailsControl()
        {
            InitializeComponent();
        }
    }
}