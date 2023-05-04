using HumanWebApi.Entities.Models;

namespace HumanWebApi.Repository.Contracts
{
    public interface IRepositoryBase
    {
        Task<List<PersonalInformation>> GetAllAsync();
        Task CreateNewPersonalAsync(PersonalInformation newPersonal);
        Task<PersonalInformation> GetByIdAsync(string id);
        Task UpdatePersonalAsync(PersonalInformation personalUpdate);
        Task DeletePersonalAsync(string id);
    }
}
