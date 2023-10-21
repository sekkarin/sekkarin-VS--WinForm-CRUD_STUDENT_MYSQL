using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_MYSQL
{
    internal class student
    {
        public string Name { get; set; }
        public string Reg { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }

        public student(string name, string reg, string @class, string section)
        {
            Name = name;
            Reg = reg;
            Class = @class;
            Section = section;
        }
    }
}
