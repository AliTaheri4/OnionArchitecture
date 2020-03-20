using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnionArchitecture.Infrastructure.Base
{
    public class BaseService<T1, T2> where T1: DbContext
     {
        private readonly T1 _context;
     
        public async Task<T2> Create(T2 model)
        {
           // await _dbset.AddAsync(model);
            _context.Entry(model).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<T2> Update(T2 model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }
          public async Task<T2> Delete(T2 model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return model;
        }
       

        public async Task<List<T>> GetListByCondition<T>(Expression<Func<T, bool>> predicate)
            where T : class
        {
               var item =await _context.Set<T>().Where(predicate).ToListAsync();
            return item;
        }

        public async Task<T> GetItemByCondition<T>(Expression<Func<T, bool>> predicate)
          where T : class
        {
           var item = await _context.Set<T>().SingleOrDefaultAsync(predicate);
            return item;
        }


        public async Task<T> GetById<T>(object id)
          where T : class
        {
            var item = await _context.Set<T>().FindAsync(id);
            return item;
        }



    }
}
