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

                Task<List<CommunityActionTemplate>> All(int limit = int.MaxValue, int offset = 0);

                Task<CommunityActionTemplate> GetExternalId(Guid externalId);
                Task<CommunityActionTemplate> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>4ed918f99945f37e627d4b1e1e290f7e</Hash>
</Codenesium>*/