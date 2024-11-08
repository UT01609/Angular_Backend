namespace TaskManagerAPI.Models
{
    public class Checklist
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public int TaskId { get; set; }
        public TaskItem? Task { get; set; }
    }
}
