using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

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
            ReloadTextBox();
            if (!String.IsNullOrEmpty(findTextBox.Text))
            {
                var collection = GetMatchCollection();
                foreach (Match match in collection)
                {
                    int firstPos = match.Index;
                    int lastPos = match.Index + match.Length;
                    var documentContent = textBox.Document.ContentStart;
                    var firstPointer = FindPointerAtTextOffset(documentContent, firstPos, false);
                    var lastPointer = FindPointerAtTextOffset(documentContent, lastPos, false);
                    var range = new TextRange(firstPointer, lastPointer);
                    range.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Aquamarine);
                }
                findTextBox.Text = String.Empty;
            }
        }

        private void ReloadTextBox()
        {
            var textRange = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
            textRange.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.White);
        }

        private TextPointer FindPointerAtTextOffset(TextPointer from, int offset, bool seekStart)
        {
            if (from == null)
                return null;

            TextPointer current = from;
            TextPointer end = from.DocumentEnd;
            int charsToGo = offset;

            while (current.CompareTo(end) != 0)
            {
                Run currentRun;
                if (current.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text &&
                    (currentRun = current.Parent as Run) != null)
                {
                    var remainingLengthInRun = current.GetOffsetToPosition(currentRun.ContentEnd);
                    if (charsToGo < remainingLengthInRun ||
                        (charsToGo == remainingLengthInRun && !seekStart))
                        return current.GetPositionAtOffset(charsToGo);
                    charsToGo -= remainingLengthInRun;
                    current = currentRun.ElementEnd;
                }
                else
                {
                    current = current.GetNextContextPosition(LogicalDirection.Forward);
                }
            }
            if (charsToGo == 0 && !seekStart)
                return end;
            return null;
        }

        private MatchCollection GetMatchCollection()
        {
            Regex regex = new Regex($"{findTextBox.Text}");
            var collection =
                regex.Matches(new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd).Text);
            return collection;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.CanUndo)
                textBox.Undo();
        }

        private void btnReplace_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(findReplaceTextBox.Text))
            {
                if (String.IsNullOrWhiteSpace(findReplaceTextBox2.Text))
                    findReplaceTextBox2.Text = " ";
                var textRange = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                textRange.Text = textRange.Text.Replace(findReplaceTextBox.Text, findReplaceTextBox2.Text);
                findReplaceTextBox.Text = String.Empty;
                findReplaceTextBox2.Text = String.Empty;
            }
            else
                MessageBox.Show("ты шо делаешь, убери", "я не шучу", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e) => ReloadTextBox();

        private void OpenFileDialog_Click(object sender, RoutedEventArgs e)
        {
            string text;
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = ".txt|.txt";
            dialog.Multiselect = false;
            dialog.InitialDirectory = $"{Directory.GetCurrentDirectory()}";
            if (dialog.ShowDialog().Value)
            {
                FileSettings.FilePath = dialog.FileName;
                using (var reader = new StreamReader(FileSettings.FilePath)) 
                    text = reader.ReadToEnd();
                var textRange = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                textRange.Text = text;
            }
        }

        private void SaveFileDialog_Click(object sender, RoutedEventArgs e)
        {
            var textRange = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
            var text = textRange.Text;
            using (var writer = new StreamWriter(FileSettings.FilePath))
            {
                writer.Write(text);
            }
        }
    }
}