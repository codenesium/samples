using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface ICommunityActionTemplateRepository
        {
                Task<CommunityActionTemplate> Create(CommunityActionTemplate item);

                Task Update(CommunityActionTemplate item);

                Task Delete(string id);

                Task<CommunityActionTemplate> Get(string id);

                Task<List<CommunityActionTemplate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<CommunityActionTemplate> GetExternalId(Guid externalId);
                Task<CommunityActionTemplate> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>1d518765e174901fa9447e16a5500726</Hash>
</Codenesium>*/