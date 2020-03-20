using OnionArchitecture.DataAccess.SqlClient;
using OnionArchitecture.Service.CustomLogServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Service.SqlClient
{
    public class SqlClient:ISqlClient
    {
        private readonly IWrapper _wrapper;
        public SqlClient(IWrapper wrapper)
        {
            _wrapper = wrapper;
            CustomLogService = new CustomLogService(_wrapper);
        }
        public ICustomLogService CustomLogService { get; set; }
    }
}
