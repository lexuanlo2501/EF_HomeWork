using EF.Models;
using testAPI.Data;

namespace EF.Data {
    public class ProductRepository:IProductRepository {

        DatacontextEF _entityFramework;

        public ProductRepository(IConfiguration config) {
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
        public IEnumerable<Product> GetProducts(){
            IEnumerable<Product> Products = _entityFramework.Product.ToList<Product>();
            return Products;
        }
        public Product GetSingleProduct(int productID){
            Product? product = _entityFramework.Product
                .Where(u => u.ID == productID)
                .FirstOrDefault<Product>();
            if(product != null){
                return product;
            }

            throw new Exception("Failed to get Product");
        }

    }

}