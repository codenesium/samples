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

                Task<List<ActionTemplateVersion>> All(int limit = int.MaxValue, int offset = 0);

                Task<ActionTemplateVersion> GetNameVersion(string name, int version);
                Task<List<ActionTemplateVersion>> GetLatestActionTemplateId(string latestActionTemplateId);
        }
}

/*<Codenesium>
    <Hash>ab8a11eecbf081c32fa9396c33af6ffc</Hash>
</Codenesium>*/