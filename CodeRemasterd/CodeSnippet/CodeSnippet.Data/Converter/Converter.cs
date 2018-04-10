using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
