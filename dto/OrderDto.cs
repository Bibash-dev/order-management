using Microsoft.VisualBasic;
using StudentOneTOManyRelation.Entities;

namespace StudentOneTOManyRelation.dto
{
    public class OrderDto
    {
        public string Name { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
    }
}