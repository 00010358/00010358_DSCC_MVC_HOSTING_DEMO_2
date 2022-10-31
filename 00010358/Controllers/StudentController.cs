using _00010358.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _00010358.Controllers
{
    public class StudentController : Controller
    {
        Uri baseAdd = new Uri("https://localhost:44303/");
        HttpClient clnt;

        public StudentController()
        {
            clnt = new HttpClient();
            clnt.BaseAddress = baseAdd;
        }

        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            //Hosted web API REST Service base url
            string Baseurl = "https://localhost:44303/";
            List<Student> StuInfo = new List<Student>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Student");

                //Checking the response is successful or not which is sent HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var StResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing the Product list
                    StuInfo = JsonConvert.DeserializeObject<List<Student>>(StResponse);
                }
                //returning the Product list to view
                return View(StuInfo);
            }
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            Student modelStu = new Student();
            HttpResponseMessage resStudent = clnt.GetAsync(clnt.BaseAddress + "api/Student/" + id).Result;
            if (resStudent.IsSuccessStatusCode)
            {
                string info = resStudent.Content.ReadAsStringAsync().Result;
                modelStu = JsonConvert.DeserializeObject<Student>(info);
            }

            return View(modelStu);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student stu)
        {
            string info = JsonConvert.SerializeObject(stu);
            StringContent cont = new StringContent(info, Encoding.UTF8, "application/json");

            HttpResponseMessage resStudent = clnt.PostAsync(clnt.BaseAddress + "api/Student", cont).Result;
            if (resStudent.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View();
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            Student modelStu = new Student();
            HttpResponseMessage resStudent = clnt.GetAsync(clnt.BaseAddress + "api/Student/" + id).Result;
            if (resStudent.IsSuccessStatusCode)
            {
                string info = resStudent.Content.ReadAsStringAsync().Result;
                modelStu = JsonConvert.DeserializeObject<Student>(info);
            }

            return View(modelStu);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student stu)
        {
            string info = JsonConvert.SerializeObject(stu);
            StringContent cont = new StringContent(info, Encoding.UTF8, "application/json");

            HttpResponseMessage resStudent = clnt.PutAsync(clnt.BaseAddress + "api/Student/" + stu.StudentID, cont).Result;
            if (resStudent.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));
            return View();
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            Student modelStu = new Student();
            HttpResponseMessage resStudent = clnt.GetAsync(clnt.BaseAddress + "api/Student/" + id).Result;
            if (resStudent.IsSuccessStatusCode)
            {
                string info = resStudent.Content.ReadAsStringAsync().Result;
                modelStu = JsonConvert.DeserializeObject<Student>(info);
            }

            return View(modelStu);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student stu)
        {
            try
            {
                HttpResponseMessage resStudent = clnt.DeleteAsync(clnt.BaseAddress + "api/Student/" + id).Result;

                if (resStudent.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
