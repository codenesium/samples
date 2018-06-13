using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IActionTemplateVersionRepository
        {
                Task<ActionTemplateVersion> Create(ActionTemplateVersion item);

                Task Update(ActionTemplateVersion item);

                Task Delete(string id);

                Task<ActionTemplateVersion> Get(string id);

                Task<List<ActionTemplateVersion>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<ActionTemplateVersion> GetNameVersion(string name, int version);
                Task<List<ActionTemplateVersion>> GetLatestActionTemplateId(string latestActionTemplateId);
        }
}

/*<Codenesium>
    <Hash>8eadfc43b36165c862e53fdff85638e1</Hash>
</Codenesium>*/