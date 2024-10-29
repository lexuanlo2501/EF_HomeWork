using EF.Models;

namespace EF.Data {
    public interface IOrdersRepository {
        public bool SaveChanges();
        public void AddEntity<T>(T entitytoAdd);
        public void RemoveEntity<T>(T entitytoRemove);
        public IEnumerable<Orders> GetOrders();
        public IEnumerable<Orders> GetSingleOrderByCustomerID(int customerID);
        public IEnumerable<Orders> GetSingleOrderByProductID(int productID);


    }


}