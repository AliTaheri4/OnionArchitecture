using OnionArchitecture.DataAccess.Data;
using OnionArchitecture.DataAccess.Entities;
using OnionArchitecture.DataAccess.ViewModels.CustomLogViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnionArchitecture.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OnionArchitecture.DataAccess.CustomLogRepositories
{
    public class CustomLogRepository : BaseService<ApplicationDbContext, CustomLog>, ICustomLogRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(CustomLogViewModel model)
        {
            try
            {
                var log = MapViewModelToModel(model);
                await _context.CustomLogs.AddAsync(log);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<bool> Update(CustomLogViewModel model)
        {
            //check for recird is exist
            var log = await IsExist(model.Id.Value);

            log.Id = model.Id.Value;
            log.CreatedTime = model.CreatedTime;
            log.EditedTime = model.EditedTime;
            log.Title = model.Title;
            log.Description = model.Description;
            log.LogType = model.LogType;
            log.Message1 = model.Message1;
            log.Message2 = model.Message2;
            // log = MapViewModelToModel(model);
            //var result = await Update(log);
            //_context.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(CustomLogViewModel model)
        {
            //check for recird is exist
            var customLog = await IsExist(model.Id.Value);
            customLog.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CustomLogViewModel>> GetList()
        {

            var logs = await _context.CustomLogs.Where(p => p.IsDeleted == false)
                .Select(p => new CustomLogViewModel()
                {
                    Id = p.Id,
                    CreatedTime = p.CreatedTime,
                    Title = p.Title,
                    Description = p.Description,
                    LogType = p.LogType,
                    Message1 = p.Message1,
                    Message2 = p.Message2
                }).ToListAsync();
            return logs;
        }

        public async Task<CustomLogViewModel> GetById(int id)
        {

            var logs = await _context.CustomLogs.Where(p => p.Id == id && p.IsDeleted == false)
                .Select(p => new CustomLogViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    LogType = p.LogType,
                    Message1 = p.Message1,
                    Message2 = p.Message2
                }).SingleOrDefaultAsync();
            return logs;
        }

        ///check for recird is exist
        public async Task<CustomLog> IsExist(int id)
        {
            var result = await _context.CustomLogs.SingleOrDefaultAsync(p => p.Id == id && p.IsDeleted == false);
            if (result != null)
                return result;

            throw new Exception("Log is not exist");
        }

        //map customlog view model to customlog entity
        public CustomLog MapViewModelToModel(CustomLogViewModel model)
        {
            try
            {
                
                var log = new CustomLog()
                {
                    CreatedTime = model.CreatedTime,
                    EditedTime = model.EditedTime,
                    Title = model.Title,
                    Description = model.Description,
                    LogType = model.LogType,
                    Message1 = model.Message1,
                    Message2 = model.Message2,
                };
                return log;
            }
            catch (Exception ex)
            {
                throw new Exception("not could log mapping");

                throw;
            }
        }


    }
}
