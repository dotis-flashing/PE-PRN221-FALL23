using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class CartonRepository : ICartoonRepo
    {
        private readonly CartoonFilm2023DBContext _context;

        public CartonRepository(CartoonFilm2023DBContext context)
        {
            _context = context;
        }

        public async Task<CartoonFilmInformation> Add(CartoonFilmInformation cartoonFilmInformation)
        {
            var carton = await _context.Set<CartoonFilmInformation>().AddAsync(cartoonFilmInformation);
            await _context.SaveChangesAsync();
            return carton.Entity;
        }

        public async Task<CartoonFilmInformation> CheckexistId(int id)
        {
            var cartoon = await _context.Set<CartoonFilmInformation>().FirstOrDefaultAsync(c => c.CartoonFilmId == id);
            if (cartoon != null)
            {
                throw new Exception("Exist Cartoon ID");

            }
            return cartoon;
        }

        public async Task Delete(CartoonFilmInformation cartoonFilmInformation)
        {
            _context.Set<CartoonFilmInformation>().Remove(cartoonFilmInformation);
            await _context.SaveChangesAsync();
        }

        public async Task<CartoonFilmInformation> GetById(int id)
        {
            var cartoon = await _context.Set<CartoonFilmInformation>().FirstOrDefaultAsync(c => c.CartoonFilmId == id);
            if (cartoon == null)
            {
                throw new Exception("Khong tim thya cartoonId");
            }
            return cartoon;
        }


        public async Task<List<CartoonFilmInformation>> GetCartoon(int query)
        {
            var list = await _context.Set<CartoonFilmInformation>()
                .Include(c => c.Producer)
                .Where(c => c.Duration.Equals(query) || c.ReleaseYear.Equals(query))
                .ToListAsync();
            if (query == 0)
            {
                list = await _context.Set<CartoonFilmInformation>().ToListAsync();
            }
            return list;
        }

        public async Task<List<CartoonFilmInformation>> ListCar()
        {
            return await _context.Set<CartoonFilmInformation>().Include(c => c.Producer).ToListAsync();
        }

        public Task<CartoonFilmInformation> Update(CartoonFilmInformation cartoonFilmInformation)
        {
            throw new NotImplementedException();
        }
    }
}
