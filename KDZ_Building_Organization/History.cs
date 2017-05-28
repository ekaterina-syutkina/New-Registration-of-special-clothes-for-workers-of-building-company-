using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Building_Organization
{
   public class History
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string firstdata;

        public string FirstData
        {
            get { return firstdata; }
            set { firstdata = value; }
        }
        
        private string myorder;

        public string MyOrder
        {
            get { return myorder; }
            set { myorder = value; }
        }
        private string seconddata;

        public string SecondData
        {
            get { return seconddata; }
            set { seconddata = value; }
        }
        public History(string name,string firstdata, string myorder,string seconddata)
        {
            this.name = name;
            this.firstdata = firstdata;
            this.myorder = myorder;
            this.seconddata = seconddata;
        }
        public History()
        {

        }
        public string Result()
        {
            return String.Format(Name + " " + FirstData + " " + MyOrder+" "+SecondData);
        }

    }
}
