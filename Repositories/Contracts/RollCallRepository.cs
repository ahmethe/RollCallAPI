using Entities.Models;

namespace Repositories.Contracts
{
    public interface IRollCallRepository : IRepositoryBase<RollCall>
    {
        void CreateOneRollCall(RollCall RollCall);
        void DeleteOneRollCall(RollCall RollCall);
        IQueryable<RollCall> GetAllRollCalls(bool trackChanges);
        RollCall GetOneRollCallById(int id, bool trackChanges);
        void UpdateOneRollCall(RollCall RollCall);
    }
}
