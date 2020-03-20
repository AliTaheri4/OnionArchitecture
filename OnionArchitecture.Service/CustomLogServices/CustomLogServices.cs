using OnionArchitecture.DataAccess.Entities;
using OnionArchitecture.DataAccess.SqlClient;
using OnionArchitecture.DataAccess.ViewModels.CustomLogViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Service.CustomLogServices
{
    public class CustomLogService:  ICustomLogService
    {
        private readonly IWrapper _dataAccess;
       public CustomLogService(IWrapper uow)
        {
            _dataAccess = uow;
        }
        public async Task<bool> Add(CustomLogViewModel model)
        {
            model.CreatedTime = DateTime.Now;
          var isSuccess= await _dataAccess.CustomLogRepository.Add(model);
            return isSuccess;
        }

        public async Task<bool> Delete(int id)
        {
            var log= await GetById(id);
            log.EditedTime = DateTime.Now;
            var isSuccess = await _dataAccess.CustomLogRepository.Delete(log);
            return isSuccess;
        }

        public async Task<CustomLogViewModel> GetById(int id)
        {
            var log= await _dataAccess.CustomLogRepository.GetById(id);
            return log;
        }

        public async Task<List<CustomLogViewModel>> GetList()
        {
            var logs = await _dataAccess.CustomLogRepository.GetList();
            return logs;
        }

        public async Task<bool> Update(CustomLogViewModel model)
        {
            model.EditedTime = DateTime.Now;
            var isSuccess = await _dataAccess.CustomLogRepository.Update(model);
            return isSuccess;
        }
    }
}
