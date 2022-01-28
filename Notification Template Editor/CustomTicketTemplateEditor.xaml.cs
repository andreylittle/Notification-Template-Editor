using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Notification_Template_Editor
{
    /// <summary>
    /// Interaction logic for CustomTicketTemplateEditor.xaml
    /// </summary>
    public partial class CustomTicketTemplateEditor : Window
    {
        public List<Canvas> listCanvas = new List<Canvas>();
        public int index;
        public CustomTicketTemplateEditor()
        {
            
            InitializeComponent();
            canvas2.Visibility = Visibility.Collapsed;
            canvas3.Visibility = Visibility.Collapsed;
            listCanvas.Add(canvas1);
            listCanvas.Add(canvas2);
            listCanvas.Add(canvas3);
            listCanvas[index].Visibility = Visibility.Visible;

            
            

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }
        private void Next_btn_Click(object sender, RoutedEventArgs e)
        {
            if (index < listCanvas.Count -1)
            {
                listCanvas[index].Visibility = Visibility.Collapsed;
                listCanvas[++index].Visibility = Visibility;
                Trace.WriteLine(index);
                
            }
        }

        private void Previous_btn_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0) 
            {
                listCanvas[index].Visibility = Visibility.Collapsed;
                listCanvas[--index].Visibility = Visibility; 
                Trace.WriteLine(index); 
            }
        }

        private void Modify_Template1_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Modify Tempalte 1");
        }

        
    }
}
