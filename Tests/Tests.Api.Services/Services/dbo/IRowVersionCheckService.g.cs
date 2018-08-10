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
    <Hash>f27007d33dc7b4eb5e1ca59b8d0d1064</Hash>
</Codenesium>*/