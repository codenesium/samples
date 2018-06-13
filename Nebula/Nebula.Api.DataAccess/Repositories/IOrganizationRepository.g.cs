using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface IOrganizationRepository
        {
                Task<Organization> Create(Organization item);

                Task Update(Organization item);

                Task Delete(int id);

                Task<Organization> Get(int id);

                Task<List<Organization>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Team>> Teams(int organizationId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>79b43514e6663759897462e9ee1e7487</Hash>
</Codenesium>*/