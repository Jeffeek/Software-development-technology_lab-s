using System.Windows;

namespace TRPO_labe_1.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFileDialog_Click(object sender, RoutedEventArgs e)
        {
            //string text;
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "txt|*.txt";
            //dialog.Multiselect = false;
            //dialog.InitialDirectory = $"{Directory.GetCurrentDirectory()}";
            ////if (dialog.ShowDialog().Value)
            ////{
            ////    FileSettings.FilePath = dialog.FileName;
            ////    using (var reader = new StreamReader(FileSettings.FilePath)) 
            ////        text = reader.ReadToEnd();
            ////    var textRange = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
            ////    textRange.Text = text;
            ////}
        }

        private void SaveFileDialog_Click(object sender, RoutedEventArgs e)
        {
            //var textRange = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
            //var text = textRange.Text;
            //using (var writer = new StreamWriter(FileSettings.FilePath))
            //{
            //    writer.Write(text);
            //}
        }
    }
}