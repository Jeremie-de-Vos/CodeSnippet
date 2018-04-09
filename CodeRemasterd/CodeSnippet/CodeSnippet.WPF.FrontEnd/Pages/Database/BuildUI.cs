using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CodeSnippet.Data.Database.External;

namespace CodeSnippet.WPF.FrontEnd.Pages.Database
{
    class BuildUI
    {
        //Get database Status
        public static void Status(StackPanel container)
        {
            container.Children.Clear();
            foreach (string i in GetDbInfo.GetAllDatabases())
                if (GetDbInfo.CreateDBConnection(i) == null)
                    StatusItem(i, DBStatus.Error, container);
                else
                    StatusItem(i, DBStatus.Oke, container);
        }
        //Create UI To show status
        private static void StatusItem(string dbName, DBStatus status, StackPanel container)
        {
            var bc = new BrushConverter();

            Canvas c = new Canvas();
            container.Children.Add(c);
            c.Height = 30;
            c.Margin = new Thickness(1, 1, 1, 1);
            c.Background = (System.Windows.Media.Brush)bc.ConvertFrom("#FF323232");

            Label l1 = new Label();
            c.Children.Add(l1);
            l1.HorizontalContentAlignment = HorizontalAlignment.Center;
            l1.VerticalContentAlignment = VerticalAlignment.Center;
            l1.HorizontalAlignment = HorizontalAlignment.Left;
            l1.VerticalAlignment = VerticalAlignment.Top;
            l1.Foreground = System.Windows.Media.Brushes.White;
            l1.Content = dbName;
            l1.FontSize = 11;
            l1.Width = 118;
            l1.Height = c.Height;

            Label statusl = new Label();
            c.Children.Add(statusl);
            statusl.HorizontalContentAlignment = HorizontalAlignment.Center;
            statusl.VerticalContentAlignment = VerticalAlignment.Center;
            statusl.HorizontalAlignment = HorizontalAlignment.Left;
            statusl.VerticalAlignment = VerticalAlignment.Top;
            statusl.SetValue(Canvas.LeftProperty, 118.0);
            statusl.Foreground = System.Windows.Media.Brushes.White;
            statusl.Content = status.ToString();
            statusl.FontSize = 11;
            statusl.Width = 80;
            statusl.Height = c.Height;
        }

    }
}
