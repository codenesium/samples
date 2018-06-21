using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IActionTemplateVersionRepository
        {
                Task<ActionTemplateVersion> Create(ActionTemplateVersion item);

                Task Update(ActionTemplateVersion item);

                Task Delete(string id);

                Task<ActionTemplateVersion> Get(string id);

                Task<List<ActionTemplateVersion>> All(int limit = int.MaxValue, int offset = 0);

                Task<ActionTemplateVersion> GetNameVersion(string name, int version);

                Task<List<ActionTemplateVersion>> GetLatestActionTemplateId(string latestActionTemplateId);
        }
}

/*<Codenesium>
    <Hash>c4184899cbc59c1e5fada85e8aeed6b4</Hash>
</Codenesium>*/