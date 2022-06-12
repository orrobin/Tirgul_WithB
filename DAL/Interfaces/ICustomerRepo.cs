using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomerRepo<T> where T : Customer
    {
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> Find(string name = default,string currency = default);
        Task<T> Get(int id);
        Task<T> Create(T customer);
        Task Update(T customer);
        Task Delete(int id);
        Task<bool> IsExist(string propName, object value);
    }
}
