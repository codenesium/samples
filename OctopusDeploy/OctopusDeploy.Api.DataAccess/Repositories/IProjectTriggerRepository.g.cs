using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IProjectTriggerRepository
        {
                Task<ProjectTrigger> Create(ProjectTrigger item);

                Task Update(ProjectTrigger item);

                Task Delete(string id);

                Task<ProjectTrigger> Get(string id);

                Task<List<ProjectTrigger>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ProjectTrigger> GetProjectIdName(string projectId, string name);
                Task<List<ProjectTrigger>> GetProjectId(string projectId);
        }
}

/*<Codenesium>
    <Hash>58e2b40b33b62b7f4a6fe24b0c1acec5</Hash>
</Codenesium>*/