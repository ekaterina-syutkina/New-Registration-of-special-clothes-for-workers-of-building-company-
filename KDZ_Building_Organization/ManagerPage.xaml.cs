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
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        string Men_name;
        public ManagerPage(string Men_name)
        {
            InitializeComponent();
            this.Men_name = Men_name;
            Name.Text = Men_name;
        }
        XmlSerializer ser =
                           new XmlSerializer(typeof(List<Worker>));
        List<Worker> list = new List<Worker>();
        private void Manager_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            TextReader reader = new StreamReader("Worker.txt");
            list = (List<Worker>)ser.Deserialize(reader);
            reader.Close();
            foreach (Worker c in list)
            {

                All_workers.Items.Add(c.Name);
            }
        }
    }
}
