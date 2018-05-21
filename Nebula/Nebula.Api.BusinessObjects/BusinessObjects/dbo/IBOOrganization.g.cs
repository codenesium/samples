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

		Task<POCOOrganization> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>0ebb2f9b595c0d72cba50f378e5e062d</Hash>
</Codenesium>*/