namespace EF.Models
{
    public partial class Orders
    {
        public int ID {get; set;}
        public int CustomerID {get; set;}
        public int ProductID {get; set;}
        public DateTime CreatedDate {get; set;} = DateTime.Now;

        public virtual Customer Customer { get; set; } 
        public virtual Product Product { get; set; } 


        public Orders() {

        }
    }
}