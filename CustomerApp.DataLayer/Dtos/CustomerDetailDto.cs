using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.DataLayer.Dtos
{
    public class CustomerDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Models.Order> Orders { get; set; }
    }
}
