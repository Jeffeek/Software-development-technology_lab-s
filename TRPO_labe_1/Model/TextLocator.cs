using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace TRPO_labe_1.Model
{
    static class TextLocator
    {
        public static void FillTextWithColor(RichTextBox textBox, string findText)
        {
            ReloadTextBox(textBox);
            if (textBox is RichTextBox rtb)
            {
                var collection = GetMatchCollection(findText,
                    new TextRange(rtb.Document.ContentStart, 
                                              rtb.Document.ContentEnd).Text);
                foreach (Match match in collection)
                {
                    int firstPos = match.Index;
                    int lastPos = match.Index + match.Length;
                    var documentContent = rtb.Document.ContentStart;
                    var firstPointer = FindPointerAtTextOffset(documentContent, firstPos, false);
                    var lastPointer = FindPointerAtTextOffset(documentContent, lastPos, false);
                    var range = new TextRange(firstPointer, lastPointer);
                    range.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Aquamarine);
                }
            }
        }

        public static void ReloadTextBox(RichTextBox obj, bool needToUndo = false)
        {
            var textRange = new TextRange(obj.Document.ContentStart, obj.Document.ContentEnd);
            textRange.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.White);
            if (needToUndo)
                obj.Undo();
        }

        private static TextPointer FindPointerAtTextOffset(TextPointer from, int offset, bool seekStart)
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

        private static MatchCollection GetMatchCollection(string findText, string whereToSearch)
        {
            char[] restricted = { '.', '?', '\\' };
            string pattern = string.Concat(findText.Select(x =>
                                        restricted.Contains(x) ? "\\" + x : x.ToString()));
            Regex regex = new Regex(pattern);
            var collection = regex.Matches(whereToSearch);
            return collection;
        }

        public static void FindAndReplace(RichTextBox rtb, string findText, string replaceText)
        {
            var textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            textRange.Text = textRange.Text.Replace(findText, replaceText);
        }
    }
}
