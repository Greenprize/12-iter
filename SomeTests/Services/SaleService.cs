using MongoDB.Driver;
using SomeTests.Models;

namespace SomeTests.Services
{
    public class SaleService
    {
        private readonly IMongoCollection<Sale> sales;

        public SaleService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("Nastya"));
            IMongoDatabase database = client.GetDatabase("Nastya");
            sales = database.GetCollection<Sale>("Sales");
        }

        public List<Sale> Get()
        {
            return sales.Find(sale => true).ToList();
        }

        public Sale Get(string id)
        {
            return sales.Find(sale => sale.Id == id).FirstOrDefault();
        }

        public Sale Create(Sale sale)
        {
            sales.InsertOne(sale);
            return sale;
        }

        public void Update(string id, Sale saleIn)
        {
            sales.ReplaceOne(sale => sale.Id == id, saleIn);
        }

        public void Remove(Sale saleIn)
        {
            sales.DeleteOne(sale => sale.Id == saleIn.Id);
        }

        public void Remove(string id)
        {
            sales.DeleteOne(sale => sale.Id == id);
        }
    }
}
