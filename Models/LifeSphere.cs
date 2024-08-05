namespace MyTaskManager.Models
{
    public class LifeSphere: Entity
    {
        public List<TaskItem> TaskItems { get; set; }
        public int Grade { get; set; }
    }
}