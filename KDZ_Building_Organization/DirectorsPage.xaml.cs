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

        XmlSerializer ser2 =
                           new XmlSerializer(typeof(List<Order>));
        List<Order> list2 = new List<Order>();
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int i = All_workers.SelectedIndex;
            All_workers.Items.RemoveAt(i);
            list.RemoveAt(i);
            TextReader reader = new StreamReader("PersonsData.txt");
            datalist = (List<PersonsData>)ser1.Deserialize(reader);
            reader.Close();
            List<PersonsData> newdatalist = new List<PersonsData>();

            reader = new StreamReader("Order.txt");
            list2 = (List<Order>)ser2.Deserialize(reader);
            reader.Close();
            List<Order> neworder = new List<Order>();
            foreach (Order o in list2)
            {
                foreach (Worker w in list)
                {
                    if (o.Name == w.Name)
                    { neworder.Add(o); }
                }
            }
            foreach (PersonsData p in datalist)
            {
                foreach (Worker w in list)
                {
                    if (p.Login == w.Login)
                    { newdatalist.Add(p); }
                }

            }
            TextWriter writer = new StreamWriter("Worker.txt");
            ser.Serialize(writer, list);
            writer.Close();
            writer = new StreamWriter("PersonsData.txt");
            ser1.Serialize(writer, newdatalist);
            writer.Close();
            writer = new StreamWriter("Order.txt");
            ser2.Serialize(writer, neworder);
            writer.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int i = All_workers.SelectedIndex;
            Worker w = list[i];
            if (w.Profession == "Директор") { MessageBox.Show("Вы зашли под именеи директора", "Вы директор", MessageBoxButton.OK); }
            else
            {
                if (w.Profession == "Заведующий складом") { MessageBox.Show("Профиль заведующего складом не доступен для просмотра", "Ошибка", MessageBoxButton.OK); }
                else
                {
                    if (w.Profession == "Электрик" || w.Profession == "Маляр")
                    { int n = 1; this.NavigationService.Navigate(new WorkersPage1(n, w.Name, w.Profession, w.Clothes_size, w.Shue_size, w.Time, w.Cas_time, w.Gloves_time, w.S_sh_time, w.S_j_time, w.S_pan_time)); All_workers.Items.Clear(); }
                    else
                    { int k = 1; this.NavigationService.Navigate(new WorkersPage(k, w.Name, w.Profession, w.Clothes_size, w.Shue_size, w.Time, w.Cas_time, w.Gloves_time, w.S_sh_time, w.W_sh_time, w.S_j_time, w.W_j_time, w.S_pan_time, w.W_pan_time)); All_workers.Items.Clear(); }
                }
            }

        }
    }
}
