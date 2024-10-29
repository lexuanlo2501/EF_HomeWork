namespace EF.Models
{
    public partial class Product
    {
        public int ID {get; set;}
        public string Name {get; set;} = "";
        public DateTime CreatedDate {get; set;} = DateTime.Now;

        public Product() {

        }
    }
}