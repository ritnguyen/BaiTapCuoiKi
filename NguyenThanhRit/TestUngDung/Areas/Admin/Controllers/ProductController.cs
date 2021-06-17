using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public NguyenThanhRitContext db;
        public ProductController()
        {
            db = new NguyenThanhRitContext();
        }
        // GET: Admin/Product
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var product = new ProductDao();
            var model = product.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var product = new ProductDao();
            var model = product.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        public ActionResult Detail(int id)
        {
            var product = new ProductDao().Find(id);
            ViewBag.Category = new CategoryDao().ViewDetail(product.Category_ID.Value);
            return View(product);
        }

        [HttpGet]
        public ActionResult Create()
        { 
            setViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase uploadhinh)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                if (uploadhinh != null && uploadhinh.ContentLength > 0)
                {
                    int id = dao.ListAll().Last().ID;
                    id++;
                    string _FileName = "";
                    int index = uploadhinh.FileName.IndexOf('.');
                    _FileName = "giay" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/Assets/Admin/images"), _FileName);
                    uploadhinh.SaveAs(_path);
                    //Product upr = db.Products.FirstOrDefault(x => x.ID == id);
                    model.Image = _FileName;
                    dao.Insert(model);
                }
                if(model!=null)
                {
                    SetAlert("Cập nhật sản phẩm mới thành công ", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    SetAlert("Cập nhật sản phẩm mới không thành công", "error");
                    // ModelState.AddModelError("", "Tạo người dùng không thành công");
                }
            }
            setViewBag(model.Category_ID);
            return View(model);
        }

        public ActionResult Showproduct()
        {
            var product = new ProductDao();
            var model = product.ListAll();
            return View(model);
        }

        public ActionResult ProductDetailes(int id)
        {
            var product = new ProductDao().Find(id);
            ViewBag.Category = new CategoryDao().ViewDetail(product.Category_ID.Value);
            return View(product);
        }


        public void setViewBag(int? selectedID=null )
        {
            var dao = new CategoryDao();
            ViewBag.Category_ID = new SelectList(dao.ListAll(), "Category_ID", "Name", selectedID);
        }
    }
}