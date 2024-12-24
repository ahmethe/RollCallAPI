using Entities.Models;

namespace Services.Contracts
{
    public interface IRollCallService
    {
        IEnumerable<RollCall> GetAllRollCalls(bool trackChanges);
        RollCall GetRollCallById(int id, bool trackChanges);
        RollCall AddRollCall(RollCall RollCall);
        void UpdateRollCall(int id, RollCall RollCall, bool trackChanges);
        void DeleteRollCall(int id, bool trackChanges);
    }
}
