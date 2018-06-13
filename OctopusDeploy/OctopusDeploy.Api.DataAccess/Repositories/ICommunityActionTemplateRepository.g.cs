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

                Task<List<CommunityActionTemplate>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<CommunityActionTemplate> GetExternalId(Guid externalId);
                Task<CommunityActionTemplate> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>7647c3dcddbab761d8e60b6e07c4febd</Hash>
</Codenesium>*/