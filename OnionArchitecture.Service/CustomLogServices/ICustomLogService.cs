using OnionArchitecture.DataAccess.Entities;
using OnionArchitecture.DataAccess.ViewModels.CustomLogViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Service.CustomLogServices
{
    public  interface ICustomLogService
    {
        Task<bool> Add(CustomLogViewModel model);
        Task<bool> Update(CustomLogViewModel model);
        Task<bool> Delete(int id);
        Task<List<CustomLogViewModel>> GetList();
        Task<CustomLogViewModel> GetById(int id);

    }
}
