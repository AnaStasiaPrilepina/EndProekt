using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace EndProekt.Models
{
    public class TaskRepository
    {
        SQLiteConnection database;
        public TaskRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Task>();
        }
        public IEnumerable<Task> GetItems()
        {
            return database.Table<Task>().ToList();
        }
        public Task GetItem(int id)
        {
            return database.Get<Task>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Task>(id);
        }
        public int SaveItem(Task item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
