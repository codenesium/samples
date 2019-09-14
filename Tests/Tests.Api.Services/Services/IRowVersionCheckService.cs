using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IRowVersionCheckService
	{
		Task<CreateResponse<ApiRowVersionCheckServerResponseModel>> Create(
			ApiRowVersionCheckServerRequestModel model);

		Task<UpdateResponse<ApiRowVersionCheckServerResponseModel>> Update(int id,
		                                                                    ApiRowVersionCheckServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiRowVersionCheckServerResponseModel> Get(int id);

		Task<List<ApiRowVersionCheckServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>4e86a9ef482e1d63b4360313d5a9a4db</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/