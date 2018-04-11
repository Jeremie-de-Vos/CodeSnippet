using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace CodeSnippet.Data.Converter
{
    public class Converter
    {
        //Convert Typefilter from string to EnumItem
        public static TypeFilter StringToTypefilter(string type)
        {
            return (TypeFilter)Enum.Parse(typeof(TypeFilter), type);
        }
        //Get all TypeFilter to a string array
        public static string[] GetAllTypeFilterToStringArray()
        { 
            return Enum.GetNames(typeof(TypeFilter));
        }

        //Convert DateFilter from string to EnumItem
        public static DateFilter StringToDateFilter(string type)
        {
            return (DateFilter)Enum.Parse(typeof(DateFilter), type);
        }
        //Get all DateFilter to a string array
        public static string[] GetAllDateFilterToStringArray()
        {
            return Enum.GetNames(typeof(DateFilter));
        }

        //Get Text from RichTextBox
        public static string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            return textRange.Text;
        }
    }
}
