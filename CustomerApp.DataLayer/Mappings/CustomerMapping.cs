using CustomerApp.DataLayer.Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace CustomerApp.DataLayer.Mappings
{
    public class CustomerMapping : ClassMapping<Models.Customer>
    {
        public CustomerMapping()
        {
            Table("Customer");
            Id(x => x.Id, m => m.Generator(Generators.Identity));

            Property(x => x.Name);
          
            Bag(x => x.Orders, m =>
            {
                m.Key(k => k.Column("CustomerId"));
                m.Inverse(true);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
            }, rel => rel.OneToMany());
        }
    }
}
