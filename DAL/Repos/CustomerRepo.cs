using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CustomerRepo<T> : ICustomerRepo<T> where T : Customer
    {
        public Context Context { get; }

        public CustomerRepo(Context context)
        {
            Context = context;
        }

        public async Task<T> Create(T customer)
        {
            customer = (await Context.Set<T>().AddAsync(customer)).Entity;
            await Context.SaveChangesAsync();
            return customer;
        }

        public async Task Delete(int id)
        {
            T customer = await Get(id);
            Context.Set<T>().Remove(customer);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(T customer)
        {
            Context.Set<T>().Update(customer);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Find(string name = default, string currency = default)
        {
            IEnumerable<T> list = await Get();
            if (!string.IsNullOrWhiteSpace(name)) list = list.Where(x => x.Name == name);
            if (!string.IsNullOrWhiteSpace(currency)) list = list.Where(x => x.Currency == currency);
            return list;
        }

        public async Task<bool> IsExist(string propName, object value)
        {
            //Context.Set<T>().SingleOrDefault()
            Expression ex;
            var setMethod = typeof(Context).GetMethods().First(m => m.Name == "Set" && m.GetGenericArguments()?.Length == 1).MakeGenericMethod(typeof(T)).Invoke(Context, new object[] { });
            var singleMethod = setMethod.GetType().GetMethods().Where(m => m.Name == "SingleOrDefault").Select(m=>m.GetParameters());
            ParameterExpression p = Expression.Parameter(typeof(T), "p");
            Expression constant = Expression.Constant(value);
            Expression property = Expression.Property(p, propName);
            Expression exp = Expression.Equal(property, constant);
            var lambdaMethod = typeof(Expression).GetMethods().Where(m => m.Name == "Lambda").Select
                (m => new { method = m, parameters = m.GetParameters(), args = m.GetGenericArguments() }).Where
                (x => x.args.Length == 1 && x.parameters[0].ParameterType == typeof(Expression) && x.parameters[1].ParameterType == typeof(ParameterExpression[])).Select
                (x => x.method).First();
            var func = Expression.GetFuncType(new[] { typeof(T), typeof(bool) });
            var pArr = new ParameterExpression[] { p };
            lambdaMethod = lambdaMethod.MakeGenericMethod(func);
            var lambda = lambdaMethod.Invoke(null, new object[] { exp, pArr });
            //var para = singleMethod.Invoke(Context.Set<T>(), new object[] { lambda });
            //if (para != null) return true;
            return false;
        }
    }
}
