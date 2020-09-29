using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using TRPO_labe_1.Model;
using TRPO_labe_1.Model.Command;
using RichTextBox = Xceed.Wpf.Toolkit.RichTextBox;

namespace TRPO_labe_1.ModelView
{
    class MainWindowModelView : ModelViewBase
    {
        private string _text;
        private string _findText;
        private string _findAndReplaceText;
        private string _findAndReplaceOnText;
        public ICommand FindTextCommand { get; }
        public ICommand UndoCommand { get; }
        public ICommand ReplaceCommand { get; }
        public ICommand RestoreTextBoxCommand { get; }

        #region Props of text

        public string Text
        {
            get => _text;
            set => SetValue(ref _text, value, nameof(Text));
        }

        public string FindText
        {
            get => _findText;
            set => SetValue(ref _findText, value, nameof(FindText));
        }

        public string FindAndReplaceText
        {
            get => _findAndReplaceText;
            set => SetValue(ref _findAndReplaceText, value, nameof(FindAndReplaceText));
        }

        public string FindAndReplaceOnText
        {
            get => _findAndReplaceOnText;
            set => SetValue(ref _findAndReplaceOnText, value, nameof(FindAndReplaceOnText));
        }

        #endregion

        #region Undo Command

        private void OnUndoTextBoxExecuted(object obj)
        {
            if (obj is RichTextBox rtb)
                rtb.Undo();
        }

        private bool CanUndoTextBoxExecute(object obj) => obj is RichTextBox rtb && rtb.CanUndo;

        #endregion

        #region FindText Command

        private void OnFindTextCommandExecuted(object obj)
        {
            if (obj is RichTextBox rtb)
                TextLocator.FillTextWithColor(rtb, FindText);
        }

        private bool CanFindTextCommandExecute(object obj)
        {
            if (string.IsNullOrWhiteSpace(FindText)) return false;
            return true;
        }


        #endregion

        #region Replace Command

        private void OnFindAndReplaceExecuted(object obj)
        {
            if (obj is RichTextBox rtb)
            {
                TextLocator.FindAndReplace(rtb, FindAndReplaceText, FindAndReplaceOnText);
            }
        }

        private bool CanFindAndReplaceExecute(object obj) =>
            !string.IsNullOrWhiteSpace(FindAndReplaceText) && 
            !string.IsNullOrWhiteSpace(FindAndReplaceOnText) &&
            !string.IsNullOrWhiteSpace(Text);

        #endregion


        public MainWindowModelView()
        {
            FindTextCommand = new RelayCommand(OnFindTextCommandExecuted, CanFindTextCommandExecute);
            UndoCommand = new RelayCommand(OnUndoTextBoxExecuted, CanUndoTextBoxExecute);
            ReplaceCommand = new RelayCommand(OnFindAndReplaceExecuted, CanFindAndReplaceExecute);
        }
    }
}
