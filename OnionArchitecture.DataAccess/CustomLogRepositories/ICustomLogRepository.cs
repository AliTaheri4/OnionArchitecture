using OnionArchitecture.DataAccess.Entities;
using OnionArchitecture.DataAccess.ViewModels.CustomLogViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.DataAccess.CustomLogRepositories
{
    public interface ICustomLogRepository
    {
        Task<bool> Add(CustomLogViewModel model);
        Task<bool> Update(CustomLogViewModel model);
        Task<bool> Delete(CustomLogViewModel model);
        Task<List<CustomLogViewModel>> GetList();
        Task<CustomLogViewModel> GetById(int id);
        Task<CustomLog> IsExist(int id);
        CustomLog MapViewModelToModel(CustomLogViewModel model);

    }
}
