using CustomerApp.DataLayer.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace CustomerApp.DataLayer.Mappings
{
    public class OrderMapping : ClassMapping<Order>
    {
        public OrderMapping()
        {
            Table("[Order]");

            Id(x => x.Id, m => m.Generator(Generators.Identity));

            Property(x => x.OrderDate);

            ManyToOne(x => x.Customer, m =>
            {
                m.Column("CustomerId");
                m.NotNullable(true);
            });

            Bag(x => x.OrderItems, m =>
            {
                m.Key(k => k.Column("OrderId"));
                m.Inverse(true);
                m.Cascade(Cascade.All);
            }, rel => rel.OneToMany());
        }
    }
}

