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

		Task<List<ApiOrganizationServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiOrganizationServerResponseModel> ByName(string name);

		Task<List<ApiTeamServerResponseModel>> TeamsByOrganizationId(int organizationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1534b81dd1f095a30572e3a467414518</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/