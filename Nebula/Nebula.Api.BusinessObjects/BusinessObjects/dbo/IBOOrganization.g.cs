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
		Task<CreateResponse<int>> Create(
			OrganizationModel model);

		Task<ActionResponse> Update(int id,
		                            OrganizationModel model);

		Task<ActionResponse> Delete(int id);

		POCOOrganization Get(int id);

		List<POCOOrganization> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4f080d2de3b6e6abe625015a9902bb7a</Hash>
</Codenesium>*/