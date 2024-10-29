using EF.Models;


namespace EF.Dtos
{
    public partial class OrderDto
    {
        public int ID {get; set;}
        public virtual Customer Customer { get; set; } 
        public virtual Product Product { get; set; } 
        public DateTime CreatedDate {get; set;} = DateTime.Now;

        public OrderDto() {

        }
    }
}