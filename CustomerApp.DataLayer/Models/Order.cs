using System;
using System.Collections.Generic;

namespace CustomerApp.DataLayer.Models
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual DateTime OrderDate { get; set;}
        public virtual Customer Customer { get; set; }
        public virtual IList<OrderDetail> OrderItems { get; set; } = new List<OrderDetail>();
    }
}
