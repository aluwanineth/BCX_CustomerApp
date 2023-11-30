namespace CustomerApp.DataLayer.Models
{
    public class OrderDetail
    {
        public virtual int Id { get; set; }
        public virtual int OrderId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string ItemDescription { get; set; }
        public virtual Order Order { get; set; }
    }
}
