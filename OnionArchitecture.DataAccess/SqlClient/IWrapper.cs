using OnionArchitecture.DataAccess.CustomLogRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.DataAccess.SqlClient
{
    public interface IWrapper
    {
        ICustomLogRepository CustomLogRepository { get; set; }
    }
}
