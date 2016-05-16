using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VY13253039Odev2
{
    class Member
    {
        string name, surname, section;

        public string Section
        {
            get { return section; }
            set { section = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Member(string name, string surname, string section)
        {
            Name = name;
            Surname = surname;
            Section = section;


        }
    }
}
