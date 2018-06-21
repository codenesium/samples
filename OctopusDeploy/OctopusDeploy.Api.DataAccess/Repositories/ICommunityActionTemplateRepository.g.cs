using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>11c59d370f70413aeb785013d2a1612c</Hash>
</Codenesium>*/