

using Domain.Entity;

namespace Application
{
    public interface ICartoonRepo
    {
        Task<List<CartoonFilmInformation>> GetCartoon(int query);
        Task<CartoonFilmInformation> Add(CartoonFilmInformation cartoonFilmInformation);
        Task<CartoonFilmInformation> Update(CartoonFilmInformation cartoonFilmInformation);
        Task Delete(CartoonFilmInformation cartoonFilmInformation);
        Task<CartoonFilmInformation> GetById(int id);
        Task<CartoonFilmInformation> CheckexistId(int id);
        Task<List<CartoonFilmInformation>> ListCar();

    }
}
