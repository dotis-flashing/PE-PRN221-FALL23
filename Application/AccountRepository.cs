
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class AccountRepository : IAccountRepo
    {
        private readonly CartoonFilm2023DBContext _context;

        public AccountRepository(CartoonFilm2023DBContext context)
        {
            _context = context;
        }

        public async Task<MemberAccount> Login(string email, string password)
        {
            var accont = await _context.Set<MemberAccount>().FirstOrDefaultAsync(c => c.Email == email && c.Password == password);
            if (accont == null)
            {
                throw new Exception("Khong the dang nhap");
            }
            return accont;
        }
    }
}
