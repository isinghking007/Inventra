using Inventra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventra.Application.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(User user,string password);

        bool VerifyPassword(User user,string storedHash,string enteredPassword);
    }
}
