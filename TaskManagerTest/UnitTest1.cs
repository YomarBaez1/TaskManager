using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public async Task CreateSuccess()
        {
            TaskModel task = new TaskModel();
            task.ID = 1;
            task.Descripcion = "Tarea 2";
            task.FechaCreacion = DateTime.Now;
            task.Estado = "Completada";
            task.Prioridad = 1;

            string _result = (string)await HttpRequest.Post("https://localhost:44396/Task/Create", task);
            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Contains(task.FechaCreacion.ToString()));


        }

        [Test]
        public async Task CreateDescriptionEmpty()
        {
            TaskModel task = new TaskModel();
            task.ID = 1;
            task.Descripcion = "";
            task.FechaCreacion = DateTime.Now;
            task.Estado = "Completada";
            task.Prioridad = 1;

            string _result = (string)await HttpRequest.Post("https://localhost:44396/Task/Create", task);
            Assert.IsNotNull(_result);
            Assert.IsFalse(_result.Contains(task.FechaCreacion.ToString()));


        }

    }
}
