using MongoDB.Driver;
using SomeTests.Models;

namespace SomeTests.Services
{
    public class ShopService
    {
        private readonly IMongoCollection<Shop> shops;

        public ShopService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("ShopBD"));
            IMongoDatabase database = client.GetDatabase("ShopBD");
            shops = database.GetCollection<Shop>("Shop");
        }

        public List<Shop> Get()
        {
            return shops.Find(sale => true).ToList();
        }

        public Shop Get(string id)
        {
            return shops.Find(shop => shop.Id == id).FirstOrDefault();
        }

        public Shop Create(Shop shop)
        {
            shops.InsertOne(shop);
            return shop;
        }

        public void Update(string id, Shop shopIn)
        {
            shops.ReplaceOne(shop => shop.Id == id, shopIn);
        }

        public void Remove(Shop shopIn)
        {
            shops.DeleteOne(shop => shop.Id == shopIn.Id);
        }

        public void Remove(string id)
        {
            shops.DeleteOne(shop => shop.Id == id);
        }
    }
}
