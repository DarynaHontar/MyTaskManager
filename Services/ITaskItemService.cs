using MyTaskManager.Models;

namespace MyTaskManager.Services
{
    public interface ITaskItemService
    {
        void AddTaskItem(CreateTaskItemRequest request);
        TaskItem? UpdateTaskItem(int id, CreateTaskItemRequest request);
        bool DeleteTaskItem(int id);
        TaskItem? GetTaskItemById(int id);
        List<TaskItem> GetTaskItems();
    }
}