using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RollCallRepository : RepositoryBase<RollCall>, IRollCallRepository
    {
        public RollCallRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateOneRollCall(RollCall RollCall) => Create(RollCall);

        public void DeleteOneRollCall(RollCall RollCall) => Delete(RollCall);

        public IQueryable<RollCall> GetAllRollCalls(bool trackChanges) =>
            FindAll(trackChanges);

        public RollCall GetOneRollCallById(int id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefault();

        public void UpdateOneRollCall(RollCall RollCall) => Update(RollCall);
    }
}
