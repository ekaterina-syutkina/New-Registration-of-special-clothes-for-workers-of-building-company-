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
    /// Логика взаимодействия для EnterPage.xaml
    /// </summary>
    public partial class EnterPage : Page
    {
        public EnterPage()
        {
            InitializeComponent();
        }
        List<Worker> list = new List<Worker>();
        List<PersonsData> datalist = new List<PersonsData>();
        XmlSerializer ser =
                           new XmlSerializer(typeof(List<Worker>));
        XmlSerializer ser1 =
                          new XmlSerializer(typeof(List<PersonsData>));
        
        private void Enter_an_account_Click(object sender, RoutedEventArgs e)
        {
            TextReader reader = new StreamReader("../../Worker.txt");
            list = (List<Worker>)ser.Deserialize(reader);
            reader.Close();
            reader = new StreamReader("../../PersonsData.txt");
            datalist = (List<PersonsData>)ser1.Deserialize(reader);
            reader.Close();
            
            int i = 0;
            Worker newworker = null;
            foreach (Worker c in list)
            {
                if (Log.Text != c.Login)
                {
                    i++;
                }
                else { newworker = c; }
            }
            if (i == list.Count)
            {
                MessageBox.Show("Пользователя с таким логином не существует", "Ошибка", MessageBoxButton.OK);
            }
            else
            {
                int t = 0;
                PersonsData newpersonsdata = null;
                foreach (PersonsData p in datalist)
                    if (Log.Text != p.Login)
                    {
                        t++;
                    }
                    else { newpersonsdata = p; }
                {
                    if (Log.Text == newpersonsdata.Login && Pass.Password == newpersonsdata.Password)
                    {
                        if (newworker.Profession == "Директор")
                        { this.NavigationService.Navigate(new DirectorsPage(newworker.Name)); }
                        else
                        {
                            if (newworker.Profession == "Заведующий складом")
                            {
                                this.NavigationService.Navigate(new ManagerPage(newworker.Name));
                            }
                            else
                            {
                                if (newworker.Profession == "Маляр" || newworker.Profession == "Электрик")
                                {
                                    int n = 0;
                                    this.NavigationService.Navigate(new WorkersPage1(n,newworker.Name, newworker.Profession, newworker.Clothes_size, newworker.Shue_size, newworker.Time, newworker.Cas_time, newworker.Gloves_time, newworker.S_sh_time, newworker.S_j_time, newworker.S_pan_time));
                                }
                                else { int k = 0; this.NavigationService.Navigate(new WorkersPage(k,newworker.Name, newworker.Profession, newworker.Clothes_size, newworker.Shue_size,newworker.Time,newworker.Cas_time,newworker.Gloves_time,newworker.S_sh_time,newworker.W_sh_time,newworker.S_j_time,newworker.W_j_time,newworker.S_pan_time,newworker.W_pan_time)); }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверно введен логин или пароль", "Ошибка", MessageBoxButton.OK);
                    }
                }
            }
        }
    }
}




