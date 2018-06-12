using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface ITeamRepository
        {
                Task<Team> Create(Team item);

                Task Update(Team item);

                Task Delete(string id);

                Task<Team> Get(string id);

                Task<List<Team>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Team> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>9dbce7f2ecb86ebf2a8ca1bb5f4e776e</Hash>
</Codenesium>*/