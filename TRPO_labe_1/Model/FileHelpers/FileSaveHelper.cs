using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace TRPO_labe_1.Model.FileHelpers
{
    public static class FileSaveHelper
    {
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
