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

        private MatchCollection GetRegexCollection()
        {
            Regex regex = new Regex($"{findTextBox.Text}");
            return regex.Matches(new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd).Text);
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            textBox.IsInactiveSelectionHighlightEnabled = true;
            textBox.Focus();
            var collection = GetRegexCollection();
            TextPointer t1, t2;
            foreach (Match reg in collection)
            {
                t1 = textBox.Document.ContentStart.GetPositionAtOffset(reg.Index-2);
                t2 = textBox.Document.ContentEnd;
                textBox.SelectionBrush = new SolidColorBrush(Color.FromRgb(12,17,200));
                textBox.SelectionTextBrush = new SolidColorBrush(Color.FromRgb(200,50,0));
                textBox.Selection.Select(t1, t2);
            }
        }
    }
}
