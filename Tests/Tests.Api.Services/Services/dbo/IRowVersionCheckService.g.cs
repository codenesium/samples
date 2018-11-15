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

		Task<List<ApiRowVersionCheckServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>139bcf649c4d49474a5baa780e76c5ce</Hash>
</Codenesium>*/