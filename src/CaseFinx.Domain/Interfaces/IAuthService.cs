using System;
using System.Collections.Generic;
using System.Text;

namespace CaseFinx.Domain.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(string userId, string email, string role);
    }
}
