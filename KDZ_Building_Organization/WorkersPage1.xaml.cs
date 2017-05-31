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
    /// Логика взаимодействия для WorkersPage1.xaml
    /// </summary>
    public partial class WorkersPage1 : Page
    {
        int i = 0;
        string Id;
        string Prof;
        string cl_size;
        string sh_size;
        string time;
        string cas_time = null;
        string gloves_time = null;
        string s_sh_time = null;
        string s_j_time = null;
        string s_pan_time = null;
        
        public WorkersPage1(int i,string Id, string Prof, string cl_size, string sh_size, string time,string cas_time, string gloves_time, string s_sh_time, string s_j_time, string s_pan_time )
        {
            InitializeComponent();
            this.i = i;
            this.Id = Id;
            this.Prof = Prof;
            this.cl_size = cl_size;
            this.sh_size = sh_size;
            this.time = time;
            this.cas_time = cas_time;
            this.gloves_time = gloves_time;
            this.s_sh_time = s_sh_time;
            this.s_j_time = s_j_time;
            this.s_pan_time = s_pan_time;
            if (cas_time == null) { Helmet_time.Text = time; } else { Helmet_time.Text = cas_time; }
            if (gloves_time == null) { Gloves_time.Text = time;} else { Gloves_time.Text = gloves_time; }
            if (s_sh_time==null) { Summer_shues_time.Text = time; } else { Summer_shues_time.Text = s_sh_time; }
            if (s_j_time==null) { Summer_Jaket_time.Text = time; } else { Summer_Jaket_time.Text = s_j_time; }
            if (s_pan_time == null) { Summer_Pans_time.Text = time; } else { Summer_Pans_time.Text = s_pan_time; }
            Workers_Id.Text = Id;
            Profession.Text = Prof;
            Clothes_Size.Text = cl_size;
            Shue_Size.Text = sh_size;
            if (i == 1) { Get_clothes.IsEnabled = false; }

        }
        List<Order> list = new List<Order>();
        XmlSerializer ser =
                           new XmlSerializer(typeof(List<Order>));
        private void Get_clothes_Click(object sender, RoutedEventArgs e)
        {
            if (Choose_date.Text != "" && order != null)
            {
                Order ord = new Order(Workers_Id.Text, Choose_date.Text, order);
                My_orders.Items.Add(ord.Result());
                list.Add(ord);
                if (!File.Exists("../../Order.txt"))
                {

                    using (StreamWriter sw = File.CreateText("../../Order.txt"))
                    {
                        ser.Serialize(sw, list);
                        sw.Close();

                    }
                }
                else
                {
                    TextWriter writer = new StreamWriter("../../Order.txt");
                    ser.Serialize(writer, list);
                    writer.Close();
                }
            }
            else { MessageBox.Show("Пожалуйста выберите предмет одежды и укажите дату заказа", "Заказ оформлен не корректно"); }
        }
        string order;
        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            order = Helmet.Content.ToString();

        }
        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            order = S_Shues.Content.ToString();

        }
        private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            order = Gloves.Content.ToString();

        }
        private void ComboBoxItem_Selected_4(object sender, RoutedEventArgs e)
        {
            order = S_J.Content.ToString();

        }
        private void ComboBoxItem_Selected_5(object sender, RoutedEventArgs e)
        {
            order = S_P.Content.ToString();

        }


        private void Grid_1_Loaded_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists("../../Order.txt"))
                {
                    TextReader reader = new StreamReader("../../Order.txt");
                    list = (List<Order>)ser.Deserialize(reader);
                    reader.Close();
                }
            }
            catch { }
            foreach (Order o in list)
            {   if (o.Name == Workers_Id.Text)
                { My_orders.Items.Add(o.Result()); }
            }
        }
    }
}
