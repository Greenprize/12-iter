using MongoDB.Driver;
using SomeTests.Models;

namespace SomeTests.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> students;

        public StudentService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("DB"));
            IMongoDatabase database = client.GetDatabase("DB");
            students = database.GetCollection<Student>("Student");
        }

        public List<Student> Get()
        {
            return students.Find(student => true).ToList();
        }

        public Student Get(string id)
        {
            return students.Find(student => student.Id == id).FirstOrDefault();
        }

        public Student Create(Student student)
        {
            students.InsertOne(student);
            return student;
        }

        public void Update(string id, Student studentIn)
        {
            students.ReplaceOne(student => student.Id == id, studentIn);
        }

        public void Remove(Student studentIn)
        {
            students.DeleteOne(student => student.Id == studentIn.Id);
        }

        public void Remove(string id)
        {
            students.DeleteOne(student => student.Id == id);
        }
    }
}
