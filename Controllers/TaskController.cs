using System.Collections.Generic;
using System.Web.Mvc;
using TaskManager.DAL;


namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private TaskDAL taskDAL;

        public TaskController()
        {
            TaskDAL taskBLL = new TaskDAL();
        }

        // Acción Index: mostrar la lista de tareas existentes
        public ActionResult Index()
        {
            return View();
        }

        // Acción Create: formulario para agregar una nueva tarea
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaskModel task)
        {
            return View();
        }

        // Acción Edit: formulario para editar una tarea existente
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // Acción Delete: eliminar una tarea
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
