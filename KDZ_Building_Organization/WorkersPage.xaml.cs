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
using System.Collections;

namespace KDZ_Building_Organization
{   
    /// <summary>
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {   string Id;
        string Prof;
        string cl_size;
        string sh_size;
        string time;
        string cas_time = null;
        string gloves_time = null;
        string s_sh_time = null;
        string w_sh_time = null;
        string s_j_time = null;
        string w_j_time = null;
        string s_pan_time = null;
        string w_pan_time = null;
        public WorkersPage(string Id, string Prof, string cl_size, string sh_size, string time, string cas_time, string gloves_time, string s_sh_time,string w_sh_time, string s_j_time,string w_j_time, string s_pan_time,string w_pan_time)
        {
            InitializeComponent();
            this.Id = Id;
            this.Prof = Prof;
            this.cl_size = cl_size;
            this.sh_size = sh_size;
            this.time = time;
            this.cas_time = cas_time;
            this.gloves_time = gloves_time;
            this.s_sh_time = s_sh_time;
            this.w_sh_time = w_sh_time;
            this.s_j_time = s_j_time;
            this.w_j_time = w_j_time;
            this.s_pan_time = s_pan_time;
            this.w_pan_time = w_pan_time;
            if (cas_time == null) { Helmet_time.Text = time; } else { Helmet_time.Text = cas_time; }
            if (gloves_time == null) { Gloves_time.Text = time; } else { Gloves_time.Text = gloves_time; }
            if (s_sh_time == null) { Summer_shues_time.Text = time; } else { Summer_shues_time.Text = s_sh_time; }
            if (w_sh_time == null) { Winter_shues_time.Text = time; } else { Winter_shues_time.Text = w_sh_time; }
            if (s_j_time == null) { Summer_Jaket_time.Text = time; } else { Summer_Jaket_time.Text = s_j_time; }
            if (w_j_time == null) { Winter_Jaket_time.Text = time; } else { Winter_Jaket_time.Text = w_j_time; }
            if (s_pan_time == null) { Summer_Pans_time.Text = time; } else { Summer_Pans_time.Text = s_pan_time; }
            if (w_pan_time == null) { Winter_Pans_time.Text = time; } else { Winter_Pans_time.Text = w_pan_time; }
            Workers_Id.Text=Id;
            Profession.Text=Prof;
            Clothes_Size.Text=cl_size;
            Shue_Size.Text=sh_size;
        }
        
        private void Workers_Id_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        List<Order> list = new List<Order>();
        XmlSerializer ser =
                           new XmlSerializer(typeof(List<Order>));
        string order = null;
        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            order = Helmet.Content.ToString();
            
        }
        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            order = W_Shues.Content.ToString();

        }
        private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            order = S_Shues.Content.ToString();

        }
        private void ComboBoxItem_Selected_4(object sender, RoutedEventArgs e)
        {
            order = Gloves.Content.ToString();

        }
        private void ComboBoxItem_Selected_5(object sender, RoutedEventArgs e)
        {
            order = S_J.Content.ToString();

        }
        private void ComboBoxItem_Selected_6(object sender, RoutedEventArgs e)
        {
            order = W_J.Content.ToString();

        }
        private void ComboBoxItem_Selected_7(object sender, RoutedEventArgs e)
        {
            order = W_P.Content.ToString();

        }
        private void ComboBoxItem_Selected_8(object sender, RoutedEventArgs e)
        {
            order = S_P.Content.ToString();

        }
        private void Get_clothes_Click(object sender, RoutedEventArgs e)
        {
            Order ord = new Order(Workers_Id.Text, Choose_date.Text,order);
            My_orders.Items.Add(ord.Result());
            list.Add(ord);
            TextWriter writer = new StreamWriter("Order.txt");
            ser.Serialize(writer, list);
            writer.Close();
        }
        

        private void Grid_0_Loaded(object sender, RoutedEventArgs e)
        {   
            try { TextReader reader = new StreamReader("Order.txt");
                list = (List<Order>)ser.Deserialize(reader);
                reader.Close(); } catch { }
            foreach (Order o in list )
            {
                My_orders.Items.Add(o.Result());
            }
        }

        
    }
}
