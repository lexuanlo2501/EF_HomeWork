namespace EF.Models
{
    public partial class Customer
    {
        public int ID {get; set;}
        public string Name {get; set;} = "";
        public string Email {get; set;} = "";
        public DateTime CreatedDate {get; set;} = DateTime.Now;

        public Customer() {

        }
    }
}