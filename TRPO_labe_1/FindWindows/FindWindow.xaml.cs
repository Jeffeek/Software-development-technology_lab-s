using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TRPO_labe_1.FindWindows
{
    /// <summary>
    /// Логика взаимодействия для FindWindow.xaml
    /// </summary>
    public partial class FindWindow : Window
    {
        private MainWindow _mw;
        public FindWindow(MainWindow MW)
        {
            InitializeComponent();
            _mw = MW;
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            Regex reg = new Regex($"{findTextBox.Text}");
            _mw.SelectText(reg.Matches(new TextRange(_mw.textBox.Document.ContentStart, _mw.textBox.Document.ContentEnd).Text));
        }
    }
}
