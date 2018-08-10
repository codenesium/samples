using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IPersonRefService
	{
		Task<CreateResponse<ApiPersonRefResponseModel>> Create(
			ApiPersonRefRequestModel model);

		Task<UpdateResponse<ApiPersonRefResponseModel>> Update(int id,
		                                                        ApiPersonRefRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPersonRefResponseModel> Get(int id);

		Task<List<ApiPersonRefResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>418188fbed63d7c775824b0861261850</Hash>
</Codenesium>*/