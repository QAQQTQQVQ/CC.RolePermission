using CC.RolePermission.DALFactory;
using CC.RolePermission.EFDAL;
using CC.RolePermission.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CC.RolePermission.IBLL;
namespace CC.RolePermission.BLL
{
    public abstract class BaseBll<T> where T : class, new()
    {
        public abstract void SetCurrentDal();
        public IDbSession DbSession
        {
            get
            {
                return DbSessionFactory.GetGurrentDbSession();
            }
        }
        public BaseBll()
        {
            SetCurrentDal();
        }
        public IBaseDal<T> CurrentDal { get; set; }
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.GetEntities(whereLambda);
        }
        public IQueryable<T> GetPageEntities<S>(int PageSize, int PageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            return CurrentDal.GetPageEntities(PageSize, PageIndex, out total, whereLambda, orderByLambda, isAsc);
        }
        public T Add(T entity)
        {
            CurrentDal.Add(entity);
            DbSession.SaveChanges();
            return entity;
        }
        public bool Update(T entity)
        {
            CurrentDal.Update(entity);
            return DbSession.SaveChanges()>0;
        }
        public bool Delete(T entity)
        {
            CurrentDal.Delete(entity);
            return DbSession.SaveChanges() > 0;
        }

        //public bool Delete(int id)
        //{
        //    CurrentDal.Delete(id);
        //    return DbSession.SaveChanges() > 0;
        //}
        public int DeleteList(List<int> ids)//真删除
        {
            foreach (var id in ids)
            {
                //DbSession.UserInfoDal.Delete(new UserInfo() { Id = id });                
                CurrentDal.Delete(id);
            }
            return DbSession.SaveChanges();//这里把SaveChanges方法提到了循环体外，自然就与数据库交互一次
        }
        public int DeleteListByLogical(List<int> ids)
        {
            CurrentDal.DeleteListByLogical(ids);
            return DbSession.SaveChanges();
        }
    }
}
