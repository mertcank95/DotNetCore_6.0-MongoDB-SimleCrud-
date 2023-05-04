using HumanWebApi.Entities.Models;
using HumanWebApi.Repository.Contracts;
using MongoDB.Driver;

namespace HumanWebApi.Repository
{
    public class PersonalRepository : IRepositoryBase
    {

        private readonly IMongoCollection<PersonalInformation> _personalCollection;

        public PersonalRepository(IMongoDatabase mongoDatabase)
        {
            _personalCollection = mongoDatabase.GetCollection<PersonalInformation>("PersonalInformation");
        }

        public async Task CreateNewPersonalAsync(PersonalInformation newPersonal)
        {
            await _personalCollection.InsertOneAsync(newPersonal);
        }

        public async Task DeletePersonalAsync(string id)
        {
            await _personalCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<PersonalInformation>> GetAllAsync()
        {
            return await _personalCollection.Find(_ => true).ToListAsync();
        }

        public async Task<PersonalInformation> GetByIdAsync(string id)
        {
            return await _personalCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        }

        public async Task UpdatePersonalAsync(PersonalInformation personalUpdate)
        {
            await _personalCollection.ReplaceOneAsync(x => x.Id == personalUpdate.Id, personalUpdate);
        }
    }
}
