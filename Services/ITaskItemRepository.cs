using MyTaskManager.Models;

namespace MyTaskManager.Services
{
    public interface ITaskItemRepository
    {
        void AddTaskItem (TaskItem taskItem);
        TaskItem? GetTaskItem (int id);
        List<TaskItem> GetTaskItems ();
        bool DeleteTaskItem (int id);
        bool UpdateTaskItem (int id, TaskItem newTaskItem);
    }
}