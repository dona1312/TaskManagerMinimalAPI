using TaskManagerMinimalAPI.Entities;
using TaskManagerMinimalAPI.Repositories.Interfaces;

namespace TaskManagerMinimalAPI.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly Dictionary<Guid, TaskEntity> _tasks = new Dictionary<Guid, TaskEntity>();
        public TasksRepository()
        {
            var task1 = new TaskEntity(Guid.NewGuid(), "Go to work", false);
            var task2 = new TaskEntity(Guid.NewGuid(), "Go to gym", true);
            var task3 = new TaskEntity(Guid.NewGuid(), "Go home", false);

            _tasks.Add(task1.ID, task1);
            _tasks.Add(task2.ID, task2);
            _tasks.Add(task3.ID, task3);
        }

        public IEnumerable<TaskEntity> GetAll() => _tasks.Values;

        public TaskEntity GetById(Guid id) => _tasks[id];

        public void Add(TaskEntity item)
        {
            _tasks.Add(item.ID, item);
        }

        public void Update(TaskEntity item) => _tasks[item.ID] = item;

        public void Delete(Guid id) => _tasks.Remove(id);
    }
}
