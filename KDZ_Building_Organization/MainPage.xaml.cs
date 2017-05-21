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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Name_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        List<Worker> list = new List<Worker>();
        List<PersonsData> datalist = new List<PersonsData>();

        private void Add_worker__Click(object sender, RoutedEventArgs e)
        {
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
            
            if (Password1.Password != RepeatPassword.Password)
            { MessageBox.Show("Введите пароль повторно ", "Пароли не совпадают", MessageBoxButton.OK); }
            else
            {
                if (Name.Text != null && StartDay.Text != null && Login.Text != null && Password1.Password != null && prof != "" && cl_size != "" && sh_size != "")
                {
                    Worker w = new Worker(Name.Text, prof, cl_size, sh_size, Login.Text);
                    PersonsData p = new PersonsData(Login.Text, Password1.Password);
                    list.Add(w);
                    foreach (Worker c in list)
                    { listBox.Items.Add(c.Result()); }
                    datalist.Add(p);
                    TextWriter writer = new StreamWriter("Worker.txt");
                    ser.Serialize(writer, list);
                    writer.Close();
                    writer = new StreamWriter("PersonsData.txt");
                    ser1.Serialize(writer, datalist);
                    writer.Close();
                }

                
                else
                {
                    MessageBox.Show("Заполните все поля ", "Ошибка", MessageBoxButton.OK);
                }
            }
            //result.Add(w);
            //Table.ItemsSource = result;*/

            //(Name.Text + " " + prof + " " + cl_size + " " + sh_size);

        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void size_M_Checked(object sender, RoutedEventArgs e)
        {

        }

        XmlSerializer ser =
                           new XmlSerializer(typeof(List<Worker>));
        XmlSerializer ser1 =
                           new XmlSerializer(typeof(List<PersonsData>));
       /* private void Page_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextWriter writer = new StreamWriter("Worker.txt");
            ser.Serialize(writer, list);
            writer.Close();
            writer = new StreamWriter("PersonsData.txt");
            ser.Serialize(writer, datalist);
            writer.Close();

        }*/

         private void FirstPage_Loaded(object sender, RoutedEventArgs e)
        {
            TextReader reader = new StreamReader("Worker.txt");
            list = (List<Worker>)ser.Deserialize(reader);
            reader.Close();
            reader = new StreamReader("PersonsData.txt");
            datalist = (List<PersonsData>)ser1.Deserialize(reader);
            reader.Close();
            foreach (Worker c in list)
            {

                listBox.Items.Add(c.Name);
            }
            
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EnterPage());
           
        }
    }
}
