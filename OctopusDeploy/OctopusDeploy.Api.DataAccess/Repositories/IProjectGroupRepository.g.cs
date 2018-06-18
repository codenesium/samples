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

                Task<List<ProjectGroup>> All(int limit = int.MaxValue, int offset = 0);

                Task<ProjectGroup> GetName(string name);
                Task<List<ProjectGroup>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>b44199d385ac44a8f4e1e166ee28218b</Hash>
</Codenesium>*/