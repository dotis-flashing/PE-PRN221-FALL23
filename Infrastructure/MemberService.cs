using Application;
using Domain.Entity;

namespace Infrastructure;

public class MemberService : IMemeberService
{
    private readonly IAccountRepo _accountRepo;

    public MemberService(IAccountRepo accountRepo)
    {
        _accountRepo = accountRepo;
    }

    public Task<MemberAccount> Login(string email, string password)
    {
        var account = _accountRepo.Login(email, password);
        return account;
    }
}
