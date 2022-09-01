using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Contexts;
using Test.Entities;

namespace Test.Data
{
#nullable disable
    public class Repository
    {

        protected TestDbContext _db = new TestDbContext();


        
        
        public async Task<Product> CreateAsycn(Product entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public IQueryable<Product> GetAll(Expression<Func<Product, bool>> expression = null)
        {

            return expression == null ? _db.Products : _db.Products.Where(expression);
        }
    }
}
