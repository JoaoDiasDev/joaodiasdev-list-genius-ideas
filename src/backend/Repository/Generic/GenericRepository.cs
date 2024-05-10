﻿using JoaoDiasDev.ProductList.Model.Base;
using JoaoDiasDev.ProductList.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace JoaoDiasDev.ProductList.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected MySQLContext _context;

        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id) { return dataset.Any(p => p.Id.Equals(id)); }

        public List<T> FindAll() { return dataset.ToList(); }

        public T FindById(long id) { return dataset.SingleOrDefault(p => p.Id.Equals(id)) ?? throw new ArgumentNullException($"{typeof(T).Name} not found"); }

        public List<T> FindWithPagedSearch(string query)
        {
            return dataset.FromSqlRaw<T>(query).ToList();
        }

        public int GetCount(string query)
        {
            var result = "";
            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    result = command?.ExecuteScalar()?.ToString();
                }
            }
            return int.TryParse(result, out int i) ? i : 0;
        }

        public T Update(T item)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return default(T) ?? throw new ArgumentNullException($"{typeof(T).Name} not found");
            }
        }
    }
}