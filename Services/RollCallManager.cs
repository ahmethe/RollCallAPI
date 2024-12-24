using Entities.Models;
using Services.Contracts;
using Repositories.Contracts;

namespace Services
{
    public class RollCallManager : IRollCallService
    {
        private readonly IRepositoryManager _manager;

        public RollCallManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<RollCall> GetAllRollCalls(bool trackChanges)
        {
            return _manager.RollCall.GetAllRollCalls(trackChanges);
        }

        public RollCall GetRollCallById(int id, bool trackChanges)
        {
            var RollCall = _manager.RollCall.GetOneRollCallById(id, trackChanges);

            if (RollCall is null)
                throw new Exception(); //

            return RollCall;
        }

        public RollCall AddRollCall(RollCall RollCall)
        {
            _manager.RollCall.CreateOneRollCall(RollCall);
            _manager.Save();

            return RollCall;
        }

        public void UpdateRollCall(int id,
            RollCall RollCall,
            bool trackChanges)
        {
            var entity = _manager.RollCall.GetOneRollCallById(id, trackChanges);
            
            if(entity is null)
                throw new Exception(); //

            //

            _manager.RollCall.UpdateOneRollCall(RollCall);
            _manager.Save();
        }

        public void DeleteRollCall(int id, bool trackChanges)
        {
            var entity = _manager.RollCall.GetOneRollCallById(id, trackChanges);

            if (entity is null)
                throw new Exception(); //

            _manager.RollCall.DeleteOneRollCall(entity);
            _manager.Save();
        }
    }
}
