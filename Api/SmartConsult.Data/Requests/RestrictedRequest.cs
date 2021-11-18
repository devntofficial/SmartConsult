using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartConsult.Data.Requests
{
    public class RestrictedRequest
    {
        public string Name { get; set; }
        public int Age { get; set; } = 0;
        public DateTime DateOfBirth { get; set; }
    }
}
