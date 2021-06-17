using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        public NguyenThanhRitContext db;

        public ProductDao()
        {
            db = new NguyenThanhRitContext();
        }

        public List<Product> ListAll()
        {
            var result = db.Products.OrderBy(x => x.Quantity).OrderByDescending(x => x.UnitCost).ToList();
            return result;
        }


        public IEnumerable<Product> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name.Contains(keysearch));
            }
            return model.OrderBy(x => x.Quantity).OrderByDescending(x => x.UnitCost).ToPagedList(page, pagesize);
        }

        public Product Find(int id)
        {
            return db.Products.Find(id);
        }

        public void Insert(Product entityUser)
        {
            db.Products.Add(entityUser);
            db.SaveChanges();
        }
    }
}
