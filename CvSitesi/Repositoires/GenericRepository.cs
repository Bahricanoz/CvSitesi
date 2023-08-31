using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using CvSitesi.Models.Entity;

namespace CvSitesi.Repositoires
{
    public class GenericRepository<T> where T : class, new()
    {
        DboCvEntities db = new DboCvEntities();
        public List<T> Tlist()
        {
            return db.Set<T>().ToList();
        }
        public void Tekle(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void Tsil(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public void Tguncelle(T p)
        {
            db.SaveChanges();
        }
        public T Tgetir(int id)
        {
            return db.Set<T>().Find(id);
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}