using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface IMachineRefTeamRepository
        {
                Task<MachineRefTeam> Create(MachineRefTeam item);

                Task Update(MachineRefTeam item);

                Task Delete(int id);

                Task<MachineRefTeam> Get(int id);

                Task<List<MachineRefTeam>> All(int limit = int.MaxValue, int offset = 0);

                Task<Machine> GetMachine(int machineId);
                Task<Team> GetTeam(int teamId);
        }
}

/*<Codenesium>
    <Hash>15dc8bb609125357c8b7ce9ea7bd9431</Hash>
</Codenesium>*/