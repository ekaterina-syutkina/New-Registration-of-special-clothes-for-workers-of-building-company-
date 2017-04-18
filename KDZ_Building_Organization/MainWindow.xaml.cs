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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
        /*private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<MyTable> result = new List<MyTable>(3);
            result.Add(new MyTable("Каска", " ", " ", " "));
            dataGrid.ItemsSource = result;
        }*/
        private void Add_worker__Click(object sender, RoutedEventArgs e)
        {
            Window1clothes Window1clothes  = new Window1clothes(Name.Text);
            Window1clothes.ShowDialog();
            

            string prof = "";
            string cl_size = "";
            string sh_size = "";

            if (size_S.IsChecked == true)
            { cl_size = "S"; }
            if (size_M.IsChecked == true)
            { cl_size = "M"; }
            if (size_L.IsChecked == true)
            { cl_size = "L"; }
            if (size_XL.IsChecked == true)
            { cl_size = "XL"; }
            if (size_XXL.IsChecked == true)
            { cl_size = "XXL"; }

            if (Director.IsChecked == true)
            { prof = Director.Content.ToString(); }
            if (worker.IsChecked == true)
            { prof = worker.Content.ToString(); }
            if (stonemason.IsChecked == true)
            { prof = stonemason.Content.ToString(); }
            if (painter.IsChecked == true)
            { prof = painter.Content.ToString(); }
            if (welder.IsChecked == true)
            { prof = welder.Content.ToString(); }
            if (electric.IsChecked == true)
            { prof = electric.Content.ToString(); }

            if (size_37.IsChecked == true)
            { sh_size = size_37.Content.ToString(); }
            if (size_38.IsChecked == true)
            { sh_size = size_38.Content.ToString(); }
            if (size_39.IsChecked == true)
            { sh_size = size_39.Content.ToString(); }
            if (size_40.IsChecked == true)
            { sh_size = size_40.Content.ToString(); }
            if (size_41.IsChecked == true)
            { sh_size = size_41.Content.ToString(); }
            if (size_42.IsChecked == true)
            { sh_size = size_42.Content.ToString(); }
            if (size_43.IsChecked == true)
            { sh_size = size_43.Content.ToString(); }
            if (size_44.IsChecked == true)
            { sh_size = size_44.Content.ToString(); }
            if (size_45.IsChecked == true)
            { sh_size = size_45.Content.ToString(); }
            
            Worker w = new Worker(Name.Text, prof, cl_size, sh_size);
            list.Add(w);
            //result.Add(w);
            //Table.ItemsSource = result;*/

            listBox.Items.Add(Name.Text + " " + prof + " " + cl_size + " " + sh_size);

        }

        /*class MyTable
        {
            public MyTable(string Clothes, string Size, string Since_Date, string For_Date)
            {
                this.Clothes = Clothes;
                this.Size = Size;
                this.Since_Date = Since_Date;
                this.For_Date = For_Date;
            }
            public string Clothes { get; set; }
            public string Size { get; set; }
            public string Since_Date { get; set; }
            public string For_Date { get; set; }
        }*/
        
        private void size_M_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
        List<Worker> list = new List<Worker>();

        XmlSerializer ser =
                           new XmlSerializer(typeof(List<Worker>));
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextWriter writer = new StreamWriter("test.txt");
            ser.Serialize(writer, list);
            writer.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
           TextReader reader = new StreamReader("test.txt");

             list = (List<Worker>)ser.Deserialize(reader);

            foreach (Worker c in list)
            {

                listBox.Items.Add(c.Name);
            }
        }
    }
}
