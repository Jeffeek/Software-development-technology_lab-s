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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TRPO_labe_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            var wind = new FindWindows.FindWindow(this);
            wind.Show();
        }

        public void SelectText(MatchCollection regexCollection)
        {
            TextPointer t1, t2;
            foreach (Match reg in regexCollection)
            {
                t1 = textBox.Document.ContentStart.GetPositionAtOffset(reg.Index);
                t2 = textBox.Document.ContentStart.GetPositionAtOffset(reg.Length);
                textBox.Selection.Select(t1, t2);
                textBox.SelectionTextBrush = ;
            } 
        }
    }
}
