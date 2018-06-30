using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface ITeamRepository
        {
                Task<Team> Create(Team item);

                Task Update(Team item);

                Task Delete(string id);

                Task<Team> Get(string id);

                Task<List<Team>> All(int limit = int.MaxValue, int offset = 0);

                Task<Team> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>ad58c68bd6974862bc607e7a2db78ad7</Hash>
</Codenesium>*/