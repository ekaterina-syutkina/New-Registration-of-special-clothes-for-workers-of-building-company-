using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Building_Organization
{
    public class Worker
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string profession;

        public string Profession
        {
            get { return profession; }
            set { profession = value; }
        }
        private string clothes_size;

        public string Clothes_size
        {
            get { return clothes_size; }
            set { clothes_size = value; }
        }
        private string shue_size;

        public string Shue_size
        {
            get { return shue_size; }
            set { shue_size = value; }
        }
        public Worker(string name, string profession, string clothes_size, string shue_size)
        {
            this.name = name;
            this.profession = profession;
            this.clothes_size = clothes_size;
            this.shue_size = shue_size;

        }
        public Worker()
        {

        }
        public string Result()
        {
            return String.Format(name, profession, clothes_size, shue_size);


        }
    }
}
