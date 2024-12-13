using YACEE.WEB.Models;

namespace YACEE.WEB.Abstraction.Interfaces
{
    public interface IYaceeAccountDbContext
    {
        IQueryable<Claim> Claims { get; }

        IQueryable<Role> Roles { get; }

        IQueryable<RoleClaim> RoleClaims { get; }

        IQueryable<User> Users { get; }

        IQueryable<UserRole> UserRoles { get; }

        IQueryable<ContactInfo> ContactInfos { get; }

        IQueryable<Client> Clients { get; }

        IQueryable<Country> Countries { get; }
    }
}
