using Application;
using Domain.Entity;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure
{
    public interface ICartonService
    {
        Task<CartoonFilmInformation> Add(CartoonFilmInformation cartoonFilmInformation);
        Task<List<CartoonFilmInformation>> Search(int query);
        Task<List<CartoonFilmInformation>> GetList();
        Task<CartoonFilmInformation> GetByid(int id);
        Task<CartoonFilmInformation> Update(int id, CartoonFilmInformation cartoonFilmInformation);
        Task Detele(int id);

    }

    public class CartoonService : ICartonService
    {
        private readonly ICartoonRepo _repo;

        public CartoonService(ICartoonRepo repo)
        {
            _repo = repo;
        }
        static string CapitalizeFirstLetter(string sentence)
        {
            string[] words = sentence.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    char[] letters = words[i].ToCharArray();
                    letters[0] = char.ToUpper(letters[0]);
                    words[i] = new string(letters);
                }
            }
            return string.Join(" ", words);
        }
        public async Task<CartoonFilmInformation> Add(CartoonFilmInformation cartoonFilmInformation)
        {
            await _repo.CheckexistId(cartoonFilmInformation.CartoonFilmId);

            //if (cartoonFilmInformation.Duration < 0)
            //{
            //    throw new Exception("cartoonFilmInformation.Duration lon hon 0");
            //}
            //if (cartoonFilmInformation.ReleaseYear <= 1990 || cartoonFilmInformation.ReleaseYear >= 2023)
            //{
            //    throw new Exception("cartoonFilmInformation.ReleaseYear <= 1990 || cartoonFilmInformation.ReleaseYear >= 2023");
            //}
            cartoonFilmInformation.CartoonFilmName = CapitalizeFirstLetter(cartoonFilmInformation.CartoonFilmName);
            //if (cartoonFilmInformation.CartoonFilmName.Length <= 15 || cartoonFilmInformation.CartoonFilmName.Length >= 200)
            //{
            //    throw new Exception("cartoonFilmInformation.CartoonFilmName.Length<=15 || cartoonFilmInformation.CartoonFilmName.Length >= 200");
            //}
            return await _repo.Add(cartoonFilmInformation);
        }

        public async Task Detele(int id)
        {
            var car = await _repo.GetById(id);
            await _repo.Delete(car);
        }

        public async Task<CartoonFilmInformation> GetByid(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<List<CartoonFilmInformation>> Search(int query)
        {
            return await _repo.GetCartoon(query);
        }

        public async Task<List<CartoonFilmInformation>> GetList()
        {
            return await _repo.ListCar();

        }

        public Task<CartoonFilmInformation> Update(int id, CartoonFilmInformation cartoonFilmInformation)
        {
            throw new NotImplementedException();
        }
    }
}
