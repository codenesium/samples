using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IProjectGroupRepository
        {
                Task<ProjectGroup> Create(ProjectGroup item);

                Task Update(ProjectGroup item);

                Task Delete(string id);

                Task<ProjectGroup> Get(string id);

                Task<List<ProjectGroup>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<ProjectGroup> GetName(string name);
                Task<List<ProjectGroup>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>c126380b9b918b76de8335cdf2c17e8d</Hash>
</Codenesium>*/