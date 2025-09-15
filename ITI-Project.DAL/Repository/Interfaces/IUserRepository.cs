using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.DAL.Models;

namespace ITI_Project.DAL.Repository.Interfaces
{
    public interface IUserRepository: GenaricRepository<User>
    {
        Task<List<User>> GetInstructors();
    }
}
