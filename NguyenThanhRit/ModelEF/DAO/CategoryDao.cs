using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        public NguyenThanhRitContext db;

        public CategoryDao()
        {
            db = new NguyenThanhRitContext();
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList(); ;
        }

        public Category ViewDetail(int id)
        {
            return db.Categories.Find(id);
        }
    }
}
