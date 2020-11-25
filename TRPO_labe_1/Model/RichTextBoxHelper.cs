﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace TRPO_labe_1.Model
{
    public class RichTextBoxHelper
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.RegisterAttached("Text", typeof(string), typeof(RichTextBoxHelper),
                new FrameworkPropertyMetadata((string)null,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault |
                    FrameworkPropertyMetadataOptions.Journal,
                    new PropertyChangedCallback(OnTextChanged),
                    new CoerceValueCallback(CoerceText), true,
                    UpdateSourceTrigger.PropertyChanged));


        /// <summary>
        /// Gets the Text property.
        /// </summary>
        public static string GetText(DependencyObject d)
        {
            return (string)d.GetValue(TextProperty);
        }

        /// <summary>
        /// Sets the Text property.
        /// </summary>
        public static void SetText(DependencyObject d, string value)
        {
            d.SetValue(TextProperty, value);
        }

        /// <summary>
        /// Returns the Text from a FlowDocument
        /// </summary>
        /// <param name="document">The document to get the text from</param>
        /// <returns>Returns a string with the text of the flow document</returns>
        public static string GetText(FlowDocument document)
        {
            return new TextRange(document.ContentStart, document.ContentEnd).Text;
        }

        /// <summary>
        /// Handles changes to the Text property.
        /// </summary>
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RichTextBox textBox = (RichTextBox)d;
            if (e.NewValue != null)
            {
                textBox.Document.Blocks.Clear();
                textBox.Document.Blocks.Add(new Paragraph(new Run(e.NewValue.ToString())));
            }
        }
    }
}
