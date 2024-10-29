using EF.Models;
using testAPI.Data;

namespace EF.Data {
    public class CustomerRepository:ICustomerRepository {

        DatacontextEF _entityFramework;

        public CustomerRepository(IConfiguration config) {
            _entityFramework = new DatacontextEF(config);
        }


        public bool SaveChanges(){
            return _entityFramework.SaveChanges() > 0;
        }
        public void AddEntity<T>(T entitytoAdd){
            if(entitytoAdd != null) {
                _entityFramework.Add(entitytoAdd);
            }
        }
        public void RemoveEntity<T>(T entitytoRemove) {
            if(entitytoRemove != null) {
                _entityFramework.Remove(entitytoRemove);
            }
        }   
        public IEnumerable<Customer> GetCustomers(){
            IEnumerable<Customer> customers = _entityFramework.Customer.ToList<Customer>();
            return customers;
        }
        public Customer GetSingleCustomer(int customerID){
            Customer? customer = _entityFramework.Customer
                .Where(u => u.ID == customerID)
                .FirstOrDefault<Customer>();
            if(customer != null){
                return customer;
            }

            throw new Exception("Failed to get user");
        }

    }

}