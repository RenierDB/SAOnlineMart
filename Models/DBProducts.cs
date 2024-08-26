using System.Data;
using System.Data.Common;

namespace SAOnlineMart.Models
{
    public interface IWriteProducts
    {
        void RemoveProduct(Product product);

        bool VerifyProduct(Product product);
    }

    public class DBProducts
    {
        protected List<Product> _products = new List<Product>();
        protected Connection _connection { get; set; }

        public DBProducts() 
        {
            _connection = new Connection();
            _products = FetchProducts("SELECT product_id, product_name, product_desc, product_price FROM product");
        }

        public int getProductCount()
        {
            return _products.Count;
        }

        public Product getProduct(int index)
        {
            return _products[index];
        }

        public List<Product> getProductList()
        {
            return _products;
        }

        protected List<Product> FetchProducts(string query)
        {
            var products = new List<Product>();
            DataTable data = _connection.queryDB(query);
            foreach (DataRow row in data.Rows)
            {
                int id = (int)row["product_id"];
                string name = (string)row["product_name"];
                string desc = (string)row["product_desc"];
                decimal price = (decimal)row["product_price"];
                products.Add(ParseProduct(id, name, desc, price));
            }
            return products;
        }

        protected Product ParseProduct(int id, string name, string desc, decimal price)
        {
            Product prod = new Product(id, name, desc, price);
            return prod;
        }
    }

    public class DBManageProducts : DBProducts, IWriteProducts
    {
        bool IWriteProducts.VerifyProduct(Product product)
        {
            string query = "SELECT * FROM product WHERE product_id = '" + product.Id;
            DataTable data = _connection.queryDB(query);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        void IWriteProducts.RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
