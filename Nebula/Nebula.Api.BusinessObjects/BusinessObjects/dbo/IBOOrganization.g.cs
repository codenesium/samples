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

		Task<POCOOrganization> Get(int id);

		Task<List<POCOOrganization>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOOrganization> Name(string name);
	}
}

/*<Codenesium>
    <Hash>e0bb927c5cc2c871a178e4eef967f16e</Hash>
</Codenesium>*/