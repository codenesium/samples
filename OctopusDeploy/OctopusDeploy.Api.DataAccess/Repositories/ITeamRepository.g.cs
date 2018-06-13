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

                Task<List<Team>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Team> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>c4193abfa0ace3645129c631a4ca4433</Hash>
</Codenesium>*/