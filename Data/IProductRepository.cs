using EF.Models;

namespace EF.Data {
    public interface IProductRepository {
        public bool SaveChanges();
        public void AddEntity<T>(T entitytoAdd);
        public void RemoveEntity<T>(T entitytoRemove);
        public IEnumerable<Product> GetProducts();
        public Product GetSingleProduct(int ProductID);


    }


}