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
using System.Windows.Shapes;

namespace KDZ_Building_Organization
{
    /// <summary>
    /// Логика взаимодействия для Window1clothes.xaml
    /// </summary>
    public partial class Window1clothes : Window
    {
        string data;
        public Window1clothes(string data)
        {
            InitializeComponent();
            this.data = data;
            Worker_id.Items.Add(data);
        }
        
        class MyTable
        {
            public MyTable(string Clothes , string Size, string Since_Date, string For_Date)
            {
                this.Clothes = Clothes;
                this.Size = Size;
                this.Since_Date = Since_Date;
                this.For_Date = For_Date;
            }
            public string Clothes { get; set; }
            public string Size { get; set; }
            public string Since_Date { get; set; }
            public string For_Date{ get; set; }
        }
        /*private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            List<MyTable> result = new List<MyTable>(3);
            result.Add(new MyTable(1, "Майкл Джексон", "Thriller", 1982));
            result.Add(new MyTable(2, "AC/DC", "Back in Black", 1980));
            result.Add(new MyTable(3, "Bee Gees", "Saturday Night Fever", 1977));
            result.Add(new MyTable(4, "Pink Floyd", "The Dark Side of the Moon", 1973));
            dataGrid.ItemsSource = result;
        }*/
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        private void Worker_id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
