using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>cb4bc1c0e768193e60fdc720cde3d2a3</Hash>
</Codenesium>*/