using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface IMachineRepository
        {
                Task<Machine> Create(Machine item);

                Task Update(Machine item);

                Task Delete(int id);

                Task<Machine> Get(int id);

                Task<List<Machine>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Link>> Links(int assignedMachineId, int limit = int.MaxValue, int offset = 0);
                Task<List<MachineRefTeam>> MachineRefTeams(int machineId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>2e124a44fd00cd4722d182c735961415</Hash>
</Codenesium>*/