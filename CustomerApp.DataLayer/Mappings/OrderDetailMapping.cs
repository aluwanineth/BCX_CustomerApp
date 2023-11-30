using CustomerApp.DataLayer.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace CustomerApp.DataLayer.Mappings
{
    public class OrderDetailMapping : ClassMapping<OrderDetail>
    {
        public OrderDetailMapping()
        {
            Table("OrderDetail");

            Id(x => x.Id, m => m.Generator(Generators.Identity));

            Property(x => x.Quantity);
            Property(x => x.Price);
            Property(x => x.ItemDescription);

            ManyToOne(x => x.Order, m =>
            {
                m.Column("OrderId");
                m.NotNullable(true);
            });
        }
    }
}