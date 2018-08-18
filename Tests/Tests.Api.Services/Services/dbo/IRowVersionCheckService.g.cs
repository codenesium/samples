using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IRowVersionCheckService
	{
		Task<CreateResponse<ApiRowVersionCheckResponseModel>> Create(
			ApiRowVersionCheckRequestModel model);

		Task<UpdateResponse<ApiRowVersionCheckResponseModel>> Update(int id,
		                                                              ApiRowVersionCheckRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiRowVersionCheckResponseModel> Get(int id);

		Task<List<ApiRowVersionCheckResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>894ff8feb9f5c6c375d5f51b8cc05c61</Hash>
</Codenesium>*/