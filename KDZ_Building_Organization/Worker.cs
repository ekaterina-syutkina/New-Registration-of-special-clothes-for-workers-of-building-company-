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
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string cas_time;

        public string Cas_time
        {
            get { return cas_time; }
            set { cas_time = value; }
        }
        private string gloves_time;

        public string Gloves_time
        {
            get { return gloves_time; }
            set { gloves_time = value; }
        }
        private string s_sh_time;

        public string S_sh_time
        {
            get { return s_sh_time; }
            set { s_sh_time = value; }
        }
        private string w_sh_time;

        public string W_sh_time 
        {
            get { return w_sh_time; }
            set { w_sh_time = value; }
        }
        private string s_j_time;

        public string S_j_time
        {
            get { return s_j_time; }
            set { s_j_time = value; }
        }
        private string w_j_time;

        public string W_j_time
        {
            get { return w_j_time; }
            set { w_j_time = value; }
        }
        private string s_pan_time;

        public string S_pan_time
        {
            get { return s_pan_time; }
            set { s_pan_time = value; }
        }
        private string w_pan_time;

        public string W_pan_time
        {
            get { return w_pan_time; }
            set { w_pan_time = value; }
        }
        private string time;

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public Worker(string name, string profession, string clothes_size, string shue_size, string login,string time)
        {
            this.name = name;
            this.profession = profession;
            this.clothes_size = clothes_size;
            this.shue_size = shue_size;
            this.login = login;
            this.time = time;
        }
        public Worker(string name, string profession, string clothes_size, string shue_size,string login)
        {
            this.name = name;
            this.profession = profession;
            this.clothes_size = clothes_size;
            this.shue_size = shue_size;
            this.login = login;
        }
        public Worker(string name, string profession, string clothes_size, string shue_size, string login,string time,string cas_time,string gloves_time, string s_sh_time,string s_j_time,string s_pan_time)
        {
            this.name = name;
            this.profession = profession;
            this.clothes_size = clothes_size;
            this.shue_size = shue_size;
            this.login = login;
            this.time = time;
            this.cas_time = cas_time;
            this.gloves_time = gloves_time;
            this.s_sh_time = s_sh_time;
            this.s_j_time = s_j_time;
            this.s_pan_time = s_pan_time;
        }
        public Worker(string name, string profession, string clothes_size, string shue_size, string login,string time, string cas_time, string gloves_time, string s_sh_time,string w_sh_time, string s_j_time,string w_j_time,string w_pan_time, string s_pan_time)
        {
            this.name = name;
            this.profession = profession;
            this.clothes_size = clothes_size;
            this.shue_size = shue_size;
            this.login = login;
            this.time = time;
            this.cas_time = cas_time;
            this.gloves_time = gloves_time;
            this.s_sh_time = s_sh_time;
            this.w_sh_time = w_sh_time;
            this.s_j_time = s_j_time;
            this.w_j_time = w_j_time;
            this.s_pan_time = s_pan_time;
            this.w_pan_time = w_pan_time;
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
