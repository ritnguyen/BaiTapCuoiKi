using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class UserDao
    {
        public NguyenThanhRitContext db;

        public UserDao()
        {
            db = new NguyenThanhRitContext();
        }

        public int login(string user, string pass)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(user) && x.Password.Contains(pass));
            var result2 = db.UserAccounts.Where(x => x.Status == "Blocked").SingleOrDefault(x => x.UserName.Contains(user) && x.Password.Contains(pass));
            if (result == null)
            {
                return 0;
            }
            else if(result2==null)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.OrderBy(x=>x.ID).ToList();
        }


        public IEnumerable<UserAccount> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.UserName.Contains(keysearch) || x.Status.Contains(keysearch));
            }
            return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }


        public string Insert(UserAccount entityUser)
        {
            var user = db.UserAccounts.Find(entityUser.UserName);
            if (user == null)
            {
                db.UserAccounts.Add(entityUser);
            }
            else
            {
                user.UserName = entityUser.UserName;
                if (!String.IsNullOrEmpty(entityUser.Password))
                {
                    user.Password = entityUser.Password;
                }
                if(!String.IsNullOrEmpty(entityUser.Status))
                {
                    user.Status = entityUser.Status;
                }
            }
            db.SaveChanges();
            return entityUser.UserName;
        }

        public bool Delete(string id)
        {
            try
            {
                var user = db.UserAccounts.Find(id);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }








        public int CheckDelete(string status)
        {
            if (status == "Blocked")
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }


        public UserAccount Find(string id)
        {
            return db.UserAccounts.Find(id);
        }
    }
}

