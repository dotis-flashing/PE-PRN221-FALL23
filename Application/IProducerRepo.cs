

using Domain.Entity;

namespace Application
{
    public interface IProducerRepo
    {
        Task<Producer> Add(Producer producer);
        Task<List<Producer>> ListProducer();
        Task<Producer> GetById(string producerId);
        Task<Producer> Update(Producer producer);
        Task<Producer> Delete(string producerId);
        Task<Producer> ExistById(string id);
    }
}
