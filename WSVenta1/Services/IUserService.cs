using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta1.Models.Request;
using WSVenta1.Models.Response;

namespace WSVenta1.Services
{
    public interface IUserService
    {
       UserResponse Auth(AuthRequest model);
    }
}
