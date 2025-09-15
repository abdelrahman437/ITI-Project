using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.DAL.Models;
using ITI_Project.DAL.Repository.Interfaces;

namespace ITI_Project.DAL.Repository
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        public SessionRepository(AppDbContext context) : base(context)
        {
        }
    }

}
