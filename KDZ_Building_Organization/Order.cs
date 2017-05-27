using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Building_Organization
{
    public class Order
    {
        private string name ;

        public string Name  
        {
            get { return name; }
            set { name  = value; }
        }
        private string data;

        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        private string myorder;

        public string MyOrder
        {
            get { return myorder; }
            set { myorder = value; }
        }
        public Order(string name,string data, string myorder)
        {
            this.name = name;
            this.data = data;
            this.myorder = myorder;

        }
        public Order()
        {
                
        }
        public string Result()
        {
           return String.Format(Name+" "+Data+" "+MyOrder);
        }

    }

}
