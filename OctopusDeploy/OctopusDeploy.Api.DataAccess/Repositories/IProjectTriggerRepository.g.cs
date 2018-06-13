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

                Task<List<ProjectTrigger>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<ProjectTrigger> GetProjectIdName(string projectId, string name);
                Task<List<ProjectTrigger>> GetProjectId(string projectId);
        }
}

/*<Codenesium>
    <Hash>f0d2cc7cd8d4f067b843c1daf6b2cc2b</Hash>
</Codenesium>*/