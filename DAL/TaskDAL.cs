using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TaskManager.DAL
{
    public class TaskDAL
    {
        private string connectionString; // Cadena de conexión a la base de datos

        public TaskDAL()
        {
            // Inicializar la cadena de conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["TaskManagerDBConnectionString"].ConnectionString;
        }

        // Método para agregar una nueva tarea
        public void AddTask(TaskModel task)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Tasks (Descripcion, FechaCreacion, Estado, Prioridad) VALUES (@Descripcion, @FechaCreacion, @Estado, @Prioridad)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Descripcion", task.Descripcion);
                    command.Parameters.AddWithValue("@FechaCreacion", task.FechaCreacion);
                    command.Parameters.AddWithValue("@Estado", task.Estado);
                    command.Parameters.AddWithValue("@Prioridad", task.Prioridad);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para actualizar una tarea existente
        public void UpdateTask(TaskModel task)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Tasks SET Descripcion = @Descripcion, FechaCreacion = @FechaCreacion, Estado = @Estado, Prioridad = @Prioridad WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Descripcion", task.Descripcion);
                    command.Parameters.AddWithValue("@FechaCreacion", task.FechaCreacion);
                    command.Parameters.AddWithValue("@Estado", task.Estado);
                    command.Parameters.AddWithValue("@Prioridad", task.Prioridad);
                    command.Parameters.AddWithValue("@ID", task.ID);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para eliminar una tarea
        public void DeleteTask(int taskId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Tasks WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", taskId);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para obtener una tarea por su ID
        public TaskModel GetTaskById(int taskId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ID, Descripcion, FechaCreacion, Estado, Prioridad FROM Tasks WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", taskId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TaskModel task = new TaskModel
                            {
                                ID = (int)reader["ID"],
                                Descripcion = (string)reader["Descripcion"],
                                FechaCreacion = (DateTime)reader["FechaCreacion"],
                                Estado = (string)reader["Estado"],
                                Prioridad = (int)reader["Prioridad"]
                            };

                            return task;
                        }
                    }
                }
            }

            return null;
        }

        // Método para obtener todas las tareas
        public List<TaskModel> GetAllTasks()
        {
            List<TaskModel> tasks = new List<TaskModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ID, Descripcion, FechaCreacion, Estado, Prioridad FROM Tasks";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TaskModel task = new TaskModel
                            {
                                ID = (int)reader["ID"],
                                Descripcion = (string)reader["Descripcion"],
                                FechaCreacion = (DateTime)reader["FechaCreacion"],
                                Estado = (string)reader["Estado"],
                                Prioridad = (int)reader["Prioridad"]
                            };

                            tasks.Add(task);
                        }
                    }
                }
            }

            return tasks;
        }
    }
}