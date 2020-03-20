using OnionArchitecture.Service.CustomLogServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Service.SqlClient
{
    public interface ISqlClient
    {
        ICustomLogService CustomLogService { get; set; }

    }
}
