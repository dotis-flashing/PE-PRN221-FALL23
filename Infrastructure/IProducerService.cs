using Domain.Entity;


namespace Infrastructure
{
    public interface IProducerService
    {
        Task<List<Producer>> GetProducer();
        Task<Producer> Add(Producer producer);
        Task<Producer> Remove(int producerId);
        Task<Producer> GetProducerById(string producerId);
        Task<Producer> Update(string producerId, Producer producer);
    }
}
