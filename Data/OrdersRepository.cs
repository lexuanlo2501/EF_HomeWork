using EF.Models;
using testAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EF.Data {
    public class OrdersRepository:IOrdersRepository {

        DatacontextEF _entityFramework;

        public OrdersRepository(IConfiguration config) {
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
        public IEnumerable<Orders> GetOrders(){
            // IEnumerable<Orders> Orders = _entityFramework.Orders.ToList();
            IEnumerable<Orders>? orders =  _entityFramework.Orders
                .Include(o => o.Customer)  
                .Include(o => o.Product)    
                .ToList();
           return orders;
        }
        public IEnumerable<Orders> GetSingleOrderByProductID(int productID){
            IEnumerable<Orders>? order = _entityFramework.Orders
                .Where(u => u.ProductID == productID).ToList();

            if(order != null){
                return order;
            }

            throw new Exception("Failed to get order");
        }

         public IEnumerable<Orders> GetSingleOrderByCustomerID(int customerID){
            IEnumerable<Orders>? order = _entityFramework.Orders
                .Where(u => u.CustomerID == customerID).ToList();

            if(order != null){
                return order;
            }

            throw new Exception("Failed to get order");
        }


    }

}