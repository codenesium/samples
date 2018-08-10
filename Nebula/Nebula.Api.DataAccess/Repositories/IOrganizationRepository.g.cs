using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial interface IOrganizationRepository
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
    <Hash>a090fce2f18fbe3f9270f8d70934b81f</Hash>
</Codenesium>*/