

using Domain.Entity;

namespace Application
{
    public interface IAccountRepo
    {
        Task<MemberAccount> Login(string email, string password);
    }
}
