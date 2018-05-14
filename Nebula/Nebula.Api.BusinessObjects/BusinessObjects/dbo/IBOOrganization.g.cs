using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOOrganization
	{
		Task<CreateResponse<POCOOrganization>> Create(
			ApiOrganizationModel model);

		Task<ActionResponse> Update(int id,
		                            ApiOrganizationModel model);

		Task<ActionResponse> Delete(int id);

		POCOOrganization Get(int id);

		List<POCOOrganization> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOOrganization Name(string name);
	}
}

/*<Codenesium>
    <Hash>8e0a31ecde1a1e1ff8140b676e3fa63e</Hash>
</Codenesium>*/