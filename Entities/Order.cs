using System;

namespace StudentOneTOManyRelation.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public virtual Employee Employee { get; set; }
        public virtual Department Department { get; set; }
    }
}