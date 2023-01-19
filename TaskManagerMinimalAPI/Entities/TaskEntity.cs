namespace TaskManagerMinimalAPI.Entities
{
    public class TaskEntity
    {
        public TaskEntity(Guid id, string name, bool completed)
        {
            ID = id;
            Name = name;
            Completed = completed;
        }

        public Guid ID { get; set; }

        public string Name { get; set; }

        public bool Completed { get; set; }
    }
}
