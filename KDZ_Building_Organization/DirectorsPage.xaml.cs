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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;

namespace KDZ_Building_Organization
{
    /// <summary>
    /// Логика взаимодействия для DirectorsPage.xaml
    /// </summary>
    public partial class DirectorsPage : Page
    {
        string Dir_name;
        public DirectorsPage(string Dir_name)
        {
            InitializeComponent();
            this.Dir_name = Dir_name;
            Directors_name.Text = Dir_name;
        }

        private void Directors_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        List<Worker> list = new List<Worker>();
        XmlSerializer ser =
                           new XmlSerializer(typeof(List<Worker>));

        private void Directors_Page_Loaded(object sender, RoutedEventArgs e)
        {
            TextReader reader = new StreamReader("Worker.txt");

            list = (List<Worker>)ser.Deserialize(reader);

            foreach (Worker c in list)
            {
                All_workers.Items.Add(c.Name);
            }
            reader.Close();
        }
        XmlSerializer ser1 =
                           new XmlSerializer(typeof(List<PersonsData>));
        List<PersonsData> datalist = new List<PersonsData>();
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int i = All_workers.SelectedIndex;
            All_workers.Items.RemoveAt(i);
            list.RemoveAt(i);
            TextReader reader = new StreamReader("PersonsData.txt");
            datalist = (List<PersonsData>)ser1.Deserialize(reader);
            reader.Close();
            List<PersonsData> newdatalist = new List<PersonsData>();
            foreach (PersonsData p in datalist)
            {
                foreach (Worker w in list)
                {
                    if (p.Login == w.Login)
                    { newdatalist.Add(p); }
                }
                TextWriter writer = new StreamWriter("Worker.txt");
                ser.Serialize(writer, list);
                writer.Close();
                writer = new StreamWriter("PersonsData.txt");
                ser1.Serialize(writer, newdatalist);
                writer.Close();
            }
        }
    }
}
