using ProjectSushi.Database.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSushi.Database.Services
{
    public interface IUseDatabaseService
    {
        Task<(bool IsSuccess, List<Roll> RollsList, string ErrorMessage)> GetAllRolls();
    }
}
