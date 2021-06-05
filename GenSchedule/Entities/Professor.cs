using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSchedule.Entities
{
    public class Professor
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        public Professor(string id, string name)
        {
            Id = id;
            Nome = name;
        }
    }
}
