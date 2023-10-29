
using Domain.Entity;

namespace Infrastructure
{
    public interface IMemeberService
    {
        Task<MemberAccount> Login(string email,string password);

    }
}
