using ConsumeMockServerTodo.Models;
using ConsumeMockServerTodo.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConsumeMockServerTodo.Controllers
{
    public class CFTController: Controller
    {
        // inmemory
        // database
        // RDBMS
        // NoSQL
        // Files

        ICFTRepository _repo;

        // tightly coupled object 
        //ITodoRepository _repo = new InMemoryRepository();
        //ITodoRepository _repo1 = new DBRepository();

        // lossely coupled implementation
        public CFTController(ICFTRepository repo)
        {
            this._repo = repo;
        }
        // [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasklist = _repo.GetAllTasks();
            return View(tasklist);
        }
        public IActionResult Details(int taskId)
        {
            var todo = _repo.GetTaskById(taskId);
            return View(todo);
        }
        public IActionResult Delete(int taskId)
        {
            var todolist = _repo.DeleteTask(taskId);
            return RedirectToAction(controllerName: "Task", actionName: "GetAllTasks"); // reload the getall page it self
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CFT newCFT) // model binded this where the views data is accepted 
        {
            if (ModelState.IsValid)
            {
                var task = _repo.AddTask(newCFT);
                return RedirectToAction("GetAllTasks");
            }
            ViewData["Message"] = "Data is not valid to create the Task";
            return View();
        }

        [HttpGet]
        public IActionResult Update(int taskId)
        {
            var oldTask = _repo.GetTaskById(taskId);
            return View(oldTask);
        }
        [HttpPost]
        public IActionResult Update(CFT newCFT)
        {
            var task = _repo.UpdateTask(newCFT.Id, newCFT);
            return RedirectToAction("GetAllTasks");
        }
    }
}
