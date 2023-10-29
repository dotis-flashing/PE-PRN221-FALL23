

using Application;
using Domain.Entity;

namespace Infrastructure;

public class ProducerSerivce : IProducerService
{
    private readonly IProducerRepo _producerRepo;

    public ProducerSerivce(IProducerRepo producerRepo)
    {
        _producerRepo = producerRepo;
    }

    public async Task<Producer> Add(Producer producer)
    {
        await _producerRepo.ExistById(producer.ProducerId);
        var produc = await _producerRepo.Add(producer);
        return produc;

    }

    public async Task<List<Producer>> GetProducer()
    {
        return await _producerRepo.ListProducer();
    }

    public async Task<Producer> GetProducerById(string producerId)
    {
        var producer = await _producerRepo.GetById(producerId);
        return producer;
    }

    public Task<Producer> Remove(int producerId)
    {
        throw new NotImplementedException();
    }

    public async Task<Producer> Update(string producerId, Producer producer)
    {
        var produc = await _producerRepo.GetById(producerId);
        if (produc != null)
        {
            produc.ProducerName = producer.ProducerName;
            produc.ProducerDescription = producer.ProducerDescription;
            await _producerRepo.Update(produc);
        }
        return produc;

    }
}
