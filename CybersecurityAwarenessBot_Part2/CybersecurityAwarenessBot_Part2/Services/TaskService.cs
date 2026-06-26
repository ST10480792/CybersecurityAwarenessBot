using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CybersecurityAwarenessBot_Part2.Database;
using CybersecurityAwarenessBot_Part2.Models;

namespace CybersecurityAwarenessBot_Part2.Services
{
    public class TaskService
    {
        private DatabaseHelper db = new DatabaseHelper();

        public void AddTask(TaskItem task)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"INSERT INTO Tasks
                                (Title, Description, ReminderDate, IsCompleted)
                                VALUES
                                (@Title,@Description,@ReminderDate,@IsCompleted)";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Title", task.Title);
                cmd.Parameters.AddWithValue("@Description", task.Description);
                cmd.Parameters.AddWithValue("@ReminderDate", task.ReminderDate);
                cmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);

                cmd.ExecuteNonQuery();
            }
        }

        public List<TaskItem> GetAllTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT * FROM Tasks";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TaskItem task = new TaskItem();

                    task.TaskID = Convert.ToInt32(reader["TaskID"]);
                    task.Title = reader["Title"].ToString();
                    task.Description = reader["Description"].ToString();

                    if (reader["ReminderDate"] != DBNull.Value)
                        task.ReminderDate = Convert.ToDateTime(reader["ReminderDate"]);

                    task.IsCompleted = Convert.ToBoolean(reader["IsCompleted"]);

                    tasks.Add(task);
                }
            }

            return tasks;
        }

        public void DeleteTask(int taskID)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM Tasks WHERE TaskID=@TaskID";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@TaskID", taskID);

                cmd.ExecuteNonQuery();
            }
        }

        public void MarkCompleted(int taskID)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"UPDATE Tasks
                                 SET IsCompleted=1
                                 WHERE TaskID=@TaskID";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@TaskID", taskID);

                cmd.ExecuteNonQuery();
            }
        }
    }
}