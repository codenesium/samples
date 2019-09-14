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

		Task<List<Organization>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Organization> ByName(string name);

		Task<List<Team>> TeamsByOrganizationId(int organizationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>60f8af9c16fac735eb4829b1903f3c4c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/