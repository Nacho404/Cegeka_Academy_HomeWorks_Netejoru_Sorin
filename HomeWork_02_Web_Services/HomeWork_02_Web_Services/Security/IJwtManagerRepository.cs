using HomeWork_02_Web_Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_02_Web_Services.Security
{
    public interface IJwtManagerRepository
    {
        Token Authenticate(UserModel users);
    }
}
