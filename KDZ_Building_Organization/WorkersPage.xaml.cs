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
        public WorkersPage(string Id, string Prof, string cl_size, string sh_size)
        {
            InitializeComponent();
            this.Id = Id;
            this.Prof = Prof;
            this.cl_size = cl_size;
            this.sh_size = sh_size;
            Workers_Id.Text=Id;
            Profession.Text=Prof;
            Clothes_Size.Text=cl_size;
            Shue_Size.Text=sh_size;
        }
        
        private void Workers_Id_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
