using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IOrganizationService
	{
		Task<CreateResponse<ApiOrganizationResponseModel>> Create(
			ApiOrganizationRequestModel model);

		Task<UpdateResponse<ApiOrganizationResponseModel>> Update(int id,
		                                                           ApiOrganizationRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiOrganizationResponseModel> Get(int id);

		Task<List<ApiOrganizationResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeamResponseModel>> Teams(int organizationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5ec139c0f5e7d1ca8be3458161975395</Hash>
</Codenesium>*/