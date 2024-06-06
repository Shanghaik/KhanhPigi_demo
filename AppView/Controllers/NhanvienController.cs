using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class NhanvienController : Controller
    {
        HttpClient client = new HttpClient();
        public NhanvienController()
        {
        }
        // GET: NhanvienController
        public ActionResult Index()
        {
            string requestURL = "https://localhost:7224/api/Nhanvien/get-all";
            var response = client.GetStringAsync(requestURL).Result;
            List<Nhanvien> result = JsonConvert.DeserializeObject<List<Nhanvien>>(response);
            return View(result);
        }

        // GET: NhanvienController/Details/5
        public ActionResult Details(Guid id)
        {
            string requestURL = $"https://localhost:7224/api/Nhanvien/get-by-id?id={id}";
            var response = client.GetStringAsync(requestURL).Result;
            Nhanvien result = JsonConvert.DeserializeObject<Nhanvien>(response);
            return View(result);
        }

        // GET: NhanvienController/Create
        public ActionResult Create()
        {
            Nhanvien nv = new Nhanvien()
            {
                Id = Guid.NewGuid(), Ten = "ABC", Email = "a@a.c", Tuoi = 30, Role = 1,
                Luong = 15000000, Trangthai = true
            };
            return View(nv);
        }

        // POST: NhanvienController/Create
        [HttpPost]
        public ActionResult Create(Nhanvien nv)
        {
            string requestURL = $"https://localhost:7224/api/Nhanvien/tao-nhanvien";
            var response = client.PostAsJsonAsync(requestURL, nv).Result;
            return RedirectToAction("Index");
        }

        // GET: NhanvienController/Edit/5
        public ActionResult Edit(Guid id)
        {
            string requestURL = $"https://localhost:7224/api/Nhanvien/get-by-id?id={id}";
            var response = client.GetStringAsync(requestURL).Result;
            Nhanvien result = JsonConvert.DeserializeObject<Nhanvien>(response);
            return View(result);
        }

        // POST: NhanvienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Nhanvien nv)
        {
            string requestURL = $"https://localhost:7224/api/Nhanvien/sua-nhanvien";
            var response = client.PutAsJsonAsync(requestURL, nv).Result;
            return RedirectToAction("Index");
        }

        // GET: NhanvienController/Delete/5
        public ActionResult Delete(Guid id)
        {
            string requestURL = $"https://localhost:7224/api/Nhanvien/xoa-by-id?id={id}";
            var response = client.DeleteAsync(requestURL).Result;
            return RedirectToAction("Index");
        }

      
    }
}
