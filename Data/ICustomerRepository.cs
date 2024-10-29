using EF.Models;

namespace EF.Data {
    public interface ICustomerRepository {
        public bool SaveChanges();
        public void AddEntity<T>(T entitytoAdd);
        public void RemoveEntity<T>(T entitytoRemove);
        public IEnumerable<Customer> GetCustomers();
        public Customer GetSingleCustomer(int customerID);


    }


}