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
    /// Interaction logic for DefaultTemplateEditor.xaml
    /// </summary>
    public partial class DefaultTemplateEditor : Window
    {
        public DefaultTemplateEditor()
        {
            InitializeComponent();
            
        }
        public string get_Header1_color()
        {
            string var = header1_txt.Text;
            var = Hex_Error_handling(var);
            return var;
        }
        public string get_Header2_color()
        {
            string var = header2_txt.Text;
            var = Hex_Error_handling(var);
            return var;
        }
        public string get_Table_color()
        {
            string var = TableOutline_txt.Text;
            var = Hex_Error_handling(var);
            return var;
        }
        public string get_folder_name()
        {
            string var = outputfolder_name_txt.Text;
            return var;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }
        private void GoBack_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            if (MessageBox.Show("By Clicking 'Ok' all data that has been entered will be removed are you sure you want to exit?", "Warning", MessageBoxButton.OKCancel) == MessageBoxResult.OK)

            {

                window.Show();
                this.Close();

            }


        }
        private void Generate_Templates_Click(object sender, RoutedEventArgs e)
        {
            if (Ticketing_checkbox.IsChecked == true)
            {
                string input_path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DefaultTicketTemplates");
                Trace.WriteLine(input_path);

                string[] files = Directory.GetFiles(input_path);

                foreach (var file in files)
                {
                    TicketTemplateFileHandler(file);

                }
            }
            if (KB_checkbox.IsChecked == true)
                {
                    string inputKB_path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DefaultKBTemplates");
                    Trace.WriteLine(inputKB_path);

                    string[] KBfiles = Directory.GetFiles(inputKB_path);

                    foreach (var kbfile in KBfiles)
                    {
                        KBTemplateFileHandler(kbfile);

                    }
             }
            if (Admin_checkbox.IsChecked == true)
            {
                string MainFolder_path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DefaultAdminTemplates\");
                ///Trace.WriteLine(MainFolder_path);

                ///string[] folders = Directory.GetFiles(MainFolder_path);
                DirectoryInfo admin_folders = new DirectoryInfo(MainFolder_path);
                DirectoryInfo[] directorys = admin_folders.GetDirectories();
                foreach (DirectoryInfo directory in directorys)
                {
                    Trace.WriteLine(directory.Name);
                    foreach (var file in directory.GetFiles())
                    {
                        string file_path = file.ToString();
                        AdminFileHandler(file_path);
                    }
                }
            
            }
            MessageBox.Show("Please Check output folder for templates");


        }
        private void TicketTemplateFileHandler(String FileName)
        {
            string file_name = null;
            file_name = System.IO.Path.GetFileName(FileName);
            Trace.WriteLine(file_name);

            string text = System.IO.File.ReadAllText(FileName);
            
            ///string header1 = header1_txt.Text;
            ///string header2 = header2_txt.Text;
            ///string boarder_color = TableOutline_txt.Text;
            text = text.Replace("[H1 COLOR]", get_Header1_color());
            text = text.Replace("[H2 COLOR]", get_Header2_color());
            text = text.Replace("[BORDER COLOR]", get_Table_color());

            string out_path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Output\" + get_folder_name() + @"\Ticket Templates" + @"\") ;
            if (!Directory.Exists(out_path))
            {
                Directory.CreateDirectory(out_path);
            }
            File.WriteAllText(out_path + file_name, text);


        }
        private void KBTemplateFileHandler(String FileName)
        {
            string file_name = null;
            file_name = System.IO.Path.GetFileName(FileName);
            Trace.WriteLine(file_name);

            string text = System.IO.File.ReadAllText(FileName);

            ///string header1 = header1_txt.Text;
            ///string header2 = header2_txt.Text;
            ///string boarder_color = TableOutline_txt.Text;
            text = text.Replace("[H1 COLOR]", get_Header1_color());
            text = text.Replace("[H2 COLOR]", get_Header2_color());
            text = text.Replace("[BORDER COLOR]", get_Table_color());

            string out_path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Output\" + get_folder_name() + @"\KB Templates\" + @"\");
            if (!Directory.Exists(out_path))
            {
                Directory.CreateDirectory(out_path);
            }
            File.WriteAllText(out_path + file_name, text);


        }

        private void AdminFileHandler(String FileName)
        {
            string file_name = null;
            file_name = System.IO.Path.GetFileName(FileName);
            Trace.WriteLine(file_name);

            ///Reads text of file 
            string text = System.IO.File.ReadAllText(FileName);

            ///Replaces text in FIle
            text = text.Replace("[H1 COLOR]", get_Header1_color());
            text = text.Replace("[H2 COLOR]", get_Header2_color());
            text = text.Replace("[BORDER COLOR]", get_Table_color());


            string MainFolder_path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DefaultAdminTemplates\");
            ///Trace.WriteLine(MainFolder_path);

            ///string[] folders = Directory.GetFiles(MainFolder_path);
            DirectoryInfo admin_folders = new DirectoryInfo(MainFolder_path);
            DirectoryInfo[] directorys = admin_folders.GetDirectories();
            foreach (DirectoryInfo directory in directorys)
            {
                Trace.WriteLine(directory.Name);
                string foldername = directory.Name;
            }

            string out_path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Output\" + get_folder_name() + @"\Admin Templates" + @"\");
            if (!Directory.Exists(out_path))
            {
                Directory.CreateDirectory(out_path);
            }
            File.WriteAllText(out_path + file_name, text);


        }

        static  string Hex_Error_handling(String Hex_Code)

        {
            //Regex rx = new Regex(@"^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$");

            //if (rx.IsMatch(Hex_Code) == false)
            //{
            //    MessageBox.Show("Invalid Hex Error");
            //    return "Bad Value";
            //}
            //else if (rx.IsMatch(Hex_Code) != false)
            //{
            //    return Hex_Code;
            //}

            if (Hex_Code == "#" || Hex_Code == null)
            {
                
                Hex_Code = "";
                return Hex_Code;
            }
            if (Hex_Code == "Black" || Hex_Code == "black" || Hex_Code == "#Black" || Hex_Code == "#black")
            {
                Hex_Code = "#000000";
                return Hex_Code;
                
            }
            if (Hex_Code == "white" || Hex_Code == "White" || Hex_Code == "#white" || Hex_Code == "#White")
            {
                Hex_Code = "#FFFFFF";
            }
            return Hex_Code;

            


        }
        



    }
}
