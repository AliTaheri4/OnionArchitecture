using OnionArchitecture.DataAccess.CustomLogRepositories;
using OnionArchitecture.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.DataAccess.SqlClient
{
    public class Wrapper: IWrapper
    {
        private readonly ApplicationDbContext _context;
        public Wrapper(ApplicationDbContext context)
        {
            _context = context;
            CustomLogRepository = new CustomLogRepository(_context);
        }
        public ICustomLogRepository CustomLogRepository { get; set; }
    }
}
