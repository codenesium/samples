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

                Task<List<MachineRefTeam>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>daaf20c107107eb982f69d953131a45a</Hash>
</Codenesium>*/