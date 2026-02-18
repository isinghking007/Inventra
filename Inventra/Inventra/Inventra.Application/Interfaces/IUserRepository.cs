using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventra.Application.Interfaces
{
  public interface IUserRepository
    {
        Task<bool> IsEmailTakenAsync(string email);
        Task AddUserAsync(Domain.Entities.User user);
        Task<Domain.Entities.User?> GetUserByEmailAsync(string email);
    }
}
