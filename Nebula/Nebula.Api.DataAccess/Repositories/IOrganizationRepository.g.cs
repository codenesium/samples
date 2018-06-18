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

                Task<List<Organization>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Team>> Teams(int organizationId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a92bd1b9bbf63c5cfd84da0bdbbf91b5</Hash>
</Codenesium>*/