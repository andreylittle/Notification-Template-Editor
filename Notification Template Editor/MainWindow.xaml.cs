using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notification_Template_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }

        private void Modify_Default_Temp_btn_Click(object sender, RoutedEventArgs e)
        {
            DefaultTemplateEditor TicketeditingWindow = new DefaultTemplateEditor();
            TicketeditingWindow.Show();
            this.Close();

        }

        private void Modify_Custom_Ticket_Template_Click(object sender, RoutedEventArgs e)
        {
            CustomTicketTemplateEditor custom_TicketTemplateEditor = new CustomTicketTemplateEditor();
            custom_TicketTemplateEditor.Show();
            this.Close();

        }
    }
}
