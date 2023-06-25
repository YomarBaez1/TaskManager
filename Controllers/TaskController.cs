using System.Collections.Generic;
using System.Web.Mvc;
using TaskManager.DAL;


namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        TaskDAL taskDAL = new TaskDAL();

        // Acción Index: mostrar la lista de tareas existentes
        public ActionResult Index()
        {
            List<TaskModel> tasks = taskDAL.GetAllTasks();

            return View(tasks);
        }

        // Acción Create: formulario para agregar una nueva tarea
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                taskDAL.AddTask(task);

                return RedirectToAction("Index");
            }

            return View(task);
        }

        // Acción Edit: formulario para editar una tarea existente
        public ActionResult Edit(int id)
        {
            TaskModel task = taskDAL.GetTaskById(id);

            if (task == null)
            {
                return HttpNotFound();
            }

            return View(task);
        }

        [HttpPost]
        public ActionResult Edit(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                taskDAL.UpdateTask(task);

                return RedirectToAction("Index");
            }

            return View(task);
        }

        // Acción Delete: eliminar una tarea
        public ActionResult Delete(int id)
        {
            TaskModel task = taskDAL.GetTaskById(id);

            if (task == null)
            {
                return HttpNotFound();
            }

            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            taskDAL.DeleteTask(id);

            return RedirectToAction("Index");
        }
    }
}
