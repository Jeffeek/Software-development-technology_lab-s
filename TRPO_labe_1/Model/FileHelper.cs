using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Microsoft.Win32;

namespace TRPO_labe_1.Model
{
    static class FileHelper
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

        public static bool SaveInfoToFile(string info)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".txt|*.txt";
            if (saveFileDialog.ShowDialog().Value)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.Write(info);
                    return true;
                }
            }

            return false;

        }
    }
}
