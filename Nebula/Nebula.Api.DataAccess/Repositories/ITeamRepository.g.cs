using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface ITeamRepository
        {
                Task<Team> Create(Team item);

                Task Update(Team item);

                Task Delete(int id);

                Task<Team> Get(int id);

                Task<List<Team>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Chain>> Chains(int teamId, int limit = int.MaxValue, int offset = 0);
                Task<List<MachineRefTeam>> MachineRefTeams(int teamId, int limit = int.MaxValue, int offset = 0);

                Task<Organization> GetOrganization(int organizationId);
        }
}

/*<Codenesium>
    <Hash>8cc021b596743ca7dea3e287e1b2f5c9</Hash>
</Codenesium>*/