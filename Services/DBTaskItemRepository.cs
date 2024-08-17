using MyTaskManager.Models;

namespace MyTaskManager.Services
{
    public class DBTaskItemRepository : ITaskItemRepository
    {
        public ApplicationDBContext DbContext { get; set; }
        public DBTaskItemRepository(ApplicationDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public void AddTaskItem(TaskItem taskItem)
        {
            DbContext.TaskItems.Add(taskItem);
            DbContext.SaveChanges();
        }

        public bool DeleteTaskItem(int id)
        {
            TaskItem? taskItem = DbContext.TaskItems.FirstOrDefault(x => x.Id == id);
            if (taskItem == null) return false;
            DbContext.TaskItems.Remove(taskItem);
            DbContext.SaveChanges();
            return true;
        }

        public List<TaskItem> GetTaskItems()
        {
            return DbContext.TaskItems.ToList();
        }

        public TaskItem? GetTaskItem(int id)
        {
            return DbContext.TaskItems.FirstOrDefault(x => x.Id == id);
        }

        public bool UpdateTaskItem(int id, TaskItem newTaskItem)
        {
            var taskItem = DbContext.TaskItems.FirstOrDefault(x => x.Id == id);
            if (taskItem == null) return false;
            taskItem = newTaskItem;
            DbContext.SaveChanges();
            return true;
        }
    }
}