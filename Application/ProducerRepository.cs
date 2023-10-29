

using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class ProducerRepository : IProducerRepo
    {
        private readonly CartoonFilm2023DBContext _context;

        public ProducerRepository(CartoonFilm2023DBContext context)
        {
            _context = context;
        }

        public async Task<Producer> Add(Producer producer)
        {
            var producerAdd = await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
            return producerAdd.Entity;
        }

        public Task<Producer> Delete(string producerId)
        {
            throw new NotImplementedException();
        }

        public async Task<Producer> ExistById(string id)
        {
            var producer = await _context.Set<Producer>().FirstOrDefaultAsync(c => c.ProducerId == id);
            if (producer != null)
            {
                throw new Exception("Exist ProducerId");
            }
            return producer;
        }

        public async Task<Producer> GetById(string producerId)
        {
            var producer = await _context.Set<Producer>().FirstOrDefaultAsync(c => c.ProducerId == producerId);
            if (producer == null)
            {
                throw new Exception("Khong tim thay Id producer");
            }
            return producer;
        }

        public async Task<List<Producer>> ListProducer()
        {
            return await _context.Set<Producer>().ToListAsync();
        }

        public async Task<Producer> Update(Producer producer)
        {
            var produce = _context.Set<Producer>().Update(producer);
            _context.SaveChanges();
            return produce.Entity;
        }
    }
}
