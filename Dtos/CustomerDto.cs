namespace EF.Dtos
{
    public partial class CustomerAddDto
    {
        public string Name {get; set;} = "";
        public string Email {get; set;} = "";
        // public DateTime CreatedDate {get; set;} = DateTime.Now;

        public CustomerAddDto() {

        }
    }
}