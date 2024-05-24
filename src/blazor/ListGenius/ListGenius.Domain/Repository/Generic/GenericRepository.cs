﻿using ListGenius.Domain.Context;
using ListGenius.Domain.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace ListGenius.Domain.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext _context;

        private DbSet<T> _dataset;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(long id)
        {
            var result = _dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _dataset.Remove(result);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public bool Exists(long id) { return _dataset.Any(p => p.Id.Equals(id)); }

        public List<T> FindAll() { return _dataset.ToList(); }

        public T FindById(long id) { return _dataset.SingleOrDefault(p => p.Id.Equals(id)) ?? throw new ArgumentNullException($"{typeof(T).Name} not found"); }

        public List<T> FindWithPagedSearch(string query)
        {
            return _dataset.FromSqlRaw<T>(query).ToList();
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
            var result = _dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
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
