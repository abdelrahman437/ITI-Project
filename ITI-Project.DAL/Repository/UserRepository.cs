using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.DAL.Models;
using ITI_Project.DAL.Models.Enums;
using ITI_Project.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.DAL.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<User>> GetInstructors()
        {
            return await _context.Users.Where(e=>e.Role== UserRole.Instructor).ToListAsync();
             
        }
    }
}
