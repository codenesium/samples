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
			OrganizationModel model);

		Task<ActionResponse> Update(int id,
		                            OrganizationModel model);

		Task<ActionResponse> Delete(int id);

		POCOOrganization Get(int id);

		List<POCOOrganization> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOOrganization Name(string name);
	}
}

/*<Codenesium>
    <Hash>ae028c28554340ae509026038a57129f</Hash>
</Codenesium>*/