using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IOrganizationService
	{
		Task<CreateResponse<ApiOrganizationServerResponseModel>> Create(
			ApiOrganizationServerRequestModel model);

		Task<UpdateResponse<ApiOrganizationServerResponseModel>> Update(int id,
		                                                                 ApiOrganizationServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiOrganizationServerResponseModel> Get(int id);

		Task<List<ApiOrganizationServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiOrganizationServerResponseModel> ByName(string name);

		Task<List<ApiTeamServerResponseModel>> TeamsByOrganizationId(int organizationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>54752f4d55a006d389eb24686be1bc80</Hash>
</Codenesium>*/