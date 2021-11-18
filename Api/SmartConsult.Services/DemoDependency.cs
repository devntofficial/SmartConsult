using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartConsult.Services
{
    public class DemoDependency : IDemoDependency
    {
        private readonly Guid _id;

        public DemoDependency()
        {
            _id = Guid.NewGuid();
        }


        public Guid getId()
        {
            return _id;
        }
    }
}
