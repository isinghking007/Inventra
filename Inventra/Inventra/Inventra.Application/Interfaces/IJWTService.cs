using Inventra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventra.Application.Interfaces
{
    public interface IJWTService
    {
        string GenerateToken(User user);
    }
}
