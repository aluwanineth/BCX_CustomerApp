using System.Collections.Generic;

namespace CustomerApp.DataLayer.Models
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Order> Orders { get; set; } = new List<Order>();
    }
}
