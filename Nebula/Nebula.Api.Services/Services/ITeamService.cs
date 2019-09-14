using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface ITeamService
	{
		Task<CreateResponse<ApiTeamServerResponseModel>> Create(
			ApiTeamServerRequestModel model);

		Task<UpdateResponse<ApiTeamServerResponseModel>> Update(int id,
		                                                         ApiTeamServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeamServerResponseModel> Get(int id);

		Task<List<ApiTeamServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiTeamServerResponseModel> ByName(string name);

		Task<List<ApiChainServerResponseModel>> ChainsByTeamId(int teamId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>06c4f6e50dba4014760a6b7084a54a5b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/