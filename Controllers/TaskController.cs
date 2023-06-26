using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Xml.Linq;
using TaskManager.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading.Tasks;

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

        // Acción GenerateReport: Generar un reporte nuevo
        public ActionResult GenerateReport()
        {
            // Obtener la lista de tareas desde el DAL
            List<TaskModel> tasks = taskDAL.GetAllTasks();

            Document document = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            document.Open();

            PdfPTable table = new PdfPTable(5);

            table.AddCell("ID");
            table.AddCell("Descripción");
            table.AddCell("Fecha de Creación");
            table.AddCell("Estado");
            table.AddCell("Prioridad");

            foreach (var task in tasks)
            {
                table.AddCell(task.ID.ToString());
                table.AddCell(task.Descripcion);
                table.AddCell(task.FechaCreacion.ToString());
                table.AddCell(task.Estado);
                table.AddCell(task.Prioridad.ToString());
            }

            document.Add(table);

            document.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TasksReport.pdf");

            Response.BinaryWrite(memoryStream.GetBuffer());

            return null;
        }

    }
}