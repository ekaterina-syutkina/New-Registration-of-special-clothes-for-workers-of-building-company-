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

        XmlSerializer ser1 =
                           new XmlSerializer(typeof(List<Order>));
        List<Order> list1 = new List<Order>();
        private void Manager_Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            TextReader reader = new StreamReader("Worker.txt");
            list = (List<Worker>)ser.Deserialize(reader);
            reader.Close();
            foreach (Worker c in list)
            {

                All_workers.Items.Add(c.Name);
            }
            try
            {
                reader = new StreamReader("Order.txt");
                list1 = (List<Order>)ser1.Deserialize(reader);
                reader.Close();
            }
            catch { }
            foreach (Order o in list1)
            {
                Requests.Items.Add(o.Result());
            }
        }
        List<Worker> list2 = new List<Worker>();
        private void Done_Click(object sender, RoutedEventArgs e)
        {
            if (DataPicker.Text == null) { MessageBox.Show("Укажите дату выполнения заказа", "Ошибка", MessageBoxButton.OK); }
            else
            {
                string newdata = DataPicker.Text;
                int i = Requests.SelectedIndex;
                Order o = list1[i];
                Worker wor = null;
                foreach (Worker w in list)
                {

                    if (w.Name != o.Name)
                    { list2.Add(w); }
                    else
                    {
                        wor = w;
                        if (o.MyOrder == "Каска") { wor.Cas_time = newdata; list2.Add(wor); }
                        if (o.MyOrder=="Рабочая обувь(зимняя)") { wor.W_sh_time = newdata; list2.Add(wor); }
                        if (o.MyOrder == "Рабочая обувь(летняя)") { wor.S_sh_time = newdata; list2.Add(wor); }
                        if (o.MyOrder == "Рабочая куртка(зимняя)") { wor.W_j_time = newdata; list2.Add(wor); }
                        if (o.MyOrder == "Рабочая куртка(летняя)") { wor.S_j_time = newdata; list2.Add(wor); }
                        if (o.MyOrder == "Рабочие штаны(зимние)") { wor.W_pan_time = newdata; list2.Add(wor); }
                        if (o.MyOrder == "Рабочие штаны(летние)") { wor.S_pan_time = newdata; list2.Add(wor); }
                        if (o.MyOrder == "Перчатки") { wor.Gloves_time = newdata; list2.Add(wor); }
                    }
                }

                Requests.Items.RemoveAt(i);
                list1.RemoveAt(i);

                TextWriter writer = new StreamWriter("Order.txt");
                ser1.Serialize(writer, list1);
                writer.Close();
                writer = new StreamWriter("Worker.txt");
                ser.Serialize(writer, list2);
                writer.Close();
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int i = All_workers.SelectedIndex;
            Worker w = list[i];
            if (w.Profession == "Директор") { MessageBox.Show("Профиль директора не доступен для просмотра", "Ошибка", MessageBoxButton.OK); }
            else
            {
                if (w.Profession == "Заведующий складом") { MessageBox.Show("Вы вошли под именем заведующего складом", "Вы заведующий складом", MessageBoxButton.OK); }
                else
                {
                    if (w.Profession == "Электрик" || w.Profession == "Маляр")
                    { int n = 1; this.NavigationService.Navigate(new WorkersPage1(n,w.Name, w.Profession, w.Clothes_size, w.Shue_size, w.Time, w.Cas_time, w.Gloves_time, w.S_sh_time, w.S_j_time, w.S_pan_time)); All_workers.Items.Clear();Requests.Items.Clear(); }
                    else
                    { int k = 1; this.NavigationService.Navigate(new WorkersPage(k,w.Name, w.Profession, w.Clothes_size, w.Shue_size, w.Time, w.Cas_time, w.Gloves_time, w.S_sh_time, w.W_sh_time, w.S_j_time, w.W_j_time, w.S_pan_time, w.W_pan_time)); All_workers.Items.Clear();Requests.Items.Clear(); }
                }
            }
        }
    }
}
