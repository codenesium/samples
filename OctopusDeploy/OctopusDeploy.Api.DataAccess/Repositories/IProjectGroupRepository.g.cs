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

                Task<List<ProjectGroup>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ProjectGroup> GetName(string name);
                Task<List<ProjectGroup>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>f6bb680c77638f6b325593fcabfb03af</Hash>
</Codenesium>*/