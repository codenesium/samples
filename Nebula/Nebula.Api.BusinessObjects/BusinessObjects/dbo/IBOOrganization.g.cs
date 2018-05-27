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
		Task<CreateResponse<ApiOrganizationResponseModel>> Create(
			ApiOrganizationRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiOrganizationRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiOrganizationResponseModel> Get(int id);

		Task<List<ApiOrganizationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiOrganizationResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>2bda2a15c332bcc25d10052801ed228a</Hash>
</Codenesium>*/