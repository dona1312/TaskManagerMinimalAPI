using System.Threading.Tasks;
using TaskManagerMinimalAPI.Entities;

namespace TaskManagerMinimalAPI.Repositories.Interfaces
{
    public interface ITasksRepository
    {
        public IEnumerable<TaskEntity> GetAll();

        public TaskEntity GetById(Guid id);

        public void Add(TaskEntity item);

        public void Update(TaskEntity item);

        public void Delete(Guid id);
    }
}
