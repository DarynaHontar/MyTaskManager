namespace MyTaskManager.Models
{
    public class TaskItem : Entity
    {
        public string Description { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsDone { get; set; }
        public int? LifeSphereId { get; set; }
    }
}