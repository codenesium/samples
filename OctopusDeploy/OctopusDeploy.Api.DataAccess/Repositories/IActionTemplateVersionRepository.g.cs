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

                Task<List<ActionTemplateVersion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ActionTemplateVersion> GetNameVersion(string name, int version);
                Task<List<ActionTemplateVersion>> GetLatestActionTemplateId(string latestActionTemplateId);
        }
}

/*<Codenesium>
    <Hash>0aba9b80dfbc6aeaba39b5333bcfcad9</Hash>
</Codenesium>*/