using System.Windows;
using WpfApplication.fake;

namespace WpfApplication
{
    public partial class Calculator : Window
    {
        public Calculator()
        {
            InitializeComponent();
            CircuitsGrid.ItemsSource = FakeFactory.GetCircuits(5);
        }
    }
}