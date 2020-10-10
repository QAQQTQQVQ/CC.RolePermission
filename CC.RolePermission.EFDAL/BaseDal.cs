using CC.RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CC.RolePermission.EFDAL
{
    public class BaseDal<T> where T:class,new()
    {
        public DbContext Db
        {
            get { return DbContentFactory.GetCurrentDbContent();}
        }

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where(whereLambda).AsQueryable();
        }
        public IQueryable<T> GetPageEntities<S>(int PageSize, int PageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            total = Db.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                var pageData = Db.Set<T>().Where(whereLambda).OrderBy<T, S>(orderByLambda)
                        .Skip(PageSize * (PageIndex - 1))
                        .Take(PageSize).AsQueryable();
                return pageData;
            }
            else
            {
                var pageData = Db.Set<T>().Where(whereLambda).OrderByDescending<T, S>(orderByLambda)
                       .Skip(PageSize * (PageIndex - 1))
                       .Take(PageSize).AsQueryable();
                return pageData;
            }
        }
        public T Add(T entity)
        {
            Db.Set<T>().Add(entity);
            return entity;
        }
        public bool Update(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return true;
        }
        public bool Delete(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return true;
        }
        public bool Delete(int id)
        {
            var entity = Db.Set<T>().Find(id);//根据id找到实体
            Db.Set<T>().Remove(entity);//由于这里先Find找到了实体，所以这里可以用Remove标记该实体要移除（删除）。如果不是先Find到实体就需要用System.Data.Entity.EntityState.Deleted
            return true;
        }
        public int DeleteListByLogical(List<int> ids)
        {
            foreach (var id in ids)
            {
                var entity = Db.Set<T>().Find(id);
                Db.Entry(entity).Property("DelFlag").CurrentValue = (int)CC.RolePermission.Model.Enum.DelFlagEnum.Deleted;
                Db.Entry(entity).Property("DelFlag").IsModified = true;//把DelFlag列标记为修改状态（尚未更新数据库），而且这样写死了DelFlag属性就要求所有实体都应该有DelFlag属性
            }
            return ids.Count();
        }

    }
}
