using System.IO;
using Microsoft.Win32;

namespace TRPO_labe_1.Model.FileHelpers
{
    static class FileLoadHelper
    {
        public static string LoadInfoFromFile(string path)
        {
            string text = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt|*.txt";
            dialog.Multiselect = false;
            dialog.InitialDirectory = $"{Directory.GetCurrentDirectory()}";
            if (dialog.ShowDialog().Value)
            {
                FileSettings.FilePath = dialog.FileName;
                using (var reader = new StreamReader(FileSettings.FilePath))
                    text = reader.ReadToEnd();
            }

            return text;
        }
    }
}
