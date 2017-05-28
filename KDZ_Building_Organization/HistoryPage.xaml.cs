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
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        public HistoryPage()
        {
            InitializeComponent();
        }
        XmlSerializer ser =
                           new XmlSerializer(typeof(List<History>));
        List<History> historylist = new List<History>();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                TextReader reader = new StreamReader("../../History.txt");
                historylist = (List<History>)ser.Deserialize(reader);
                reader.Close();
            }
            catch { }
            foreach(History his in historylist)
            {
                All_orders.Items.Add(his.Result());
            }
        }
    }
}
