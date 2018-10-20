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

		Task<ApiOrganizationResponseModel> ByName(string name);

		Task<List<ApiTeamResponseModel>> TeamsByOrganizationId(int organizationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7b379e6cdf5a49d7a2f64d0766d6ac9a</Hash>
</Codenesium>*/