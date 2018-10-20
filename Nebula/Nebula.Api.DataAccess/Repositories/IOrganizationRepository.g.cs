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

		Task<Organization> ByName(string name);

		Task<List<Team>> TeamsByOrganizationId(int organizationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6986dafa3aaf5b2ed530d9e6b95038b2</Hash>
</Codenesium>*/