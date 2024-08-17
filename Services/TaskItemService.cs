using MyTaskManager.Models;

namespace MyTaskManager.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository taskRegister;
        private readonly ILifeSphereRepository lifeSphereRegister;

        public TaskItemService(ITaskItemRepository taskRegister, ILifeSphereRepository lifeSphereRegister)
        {
            this.taskRegister = taskRegister;
            this.lifeSphereRegister = lifeSphereRegister;
        }
        public void AddTaskItem(CreateTaskItemRequest request)
        {
            TaskItem taskItem = new();
            taskItem = InitializeTask(taskItem, request);
            if (taskItem != null)
                taskRegister.AddTaskItem(taskItem);
        }

        public bool DeleteTaskItem(int id)
        {
            int count = taskRegister.GetTaskItems().Count;
            var task = taskRegister.GetTaskItem(id);
            if (task == null) return false;
            taskRegister.DeleteTaskItem(id);
            int countAfterDeleting = taskRegister.GetTaskItems().Count;
            if (countAfterDeleting >= count) return false;
            return true;
        }

        public TaskItem? GetTaskItemById(int id)
        {
            return taskRegister.GetTaskItem(id);
        }

        public List<TaskItem> GetTaskItems()
        {
            return taskRegister.GetTaskItems();
        }

        public TaskItem? UpdateTaskItem(int id, CreateTaskItemRequest request)
        {
            var task = taskRegister.GetTaskItem(id);
            if (task != null)
            {
                InitializeTask(task, request);
                taskRegister.UpdateTaskItem(id, (TaskItem)task);
            }
            return task;
        }

        private TaskItem InitializeTask(TaskItem taskItem, CreateTaskItemRequest request)
        {
            taskItem.Title = request.Title;
            taskItem.Deadline = request.DeadLine;
            taskItem.Description = request.Description;
            bool result = ExistsLifeSpheresId(request.LifeSphereId);

            if (request.LifeSphereId != null && result)
                taskItem.LifeSphereId = request.LifeSphereId;
            else
                taskItem.LifeSphereId = null;
            return taskItem;
        }

        private bool ExistsLifeSpheresId(int? id)
        {
            var list = GetLifeSpheresId();
            if (id != null)
                return list.Contains((int)id);
            else
                return false;
        }

        private List<int> GetLifeSpheresId()
        {
            List<int> sphereIdList = new();
            var spheres = lifeSphereRegister.GetLifeSpheres();
            foreach (var item in spheres)
            {
                sphereIdList.Add(item.Id);
            }
            return sphereIdList;
        }
    }
}