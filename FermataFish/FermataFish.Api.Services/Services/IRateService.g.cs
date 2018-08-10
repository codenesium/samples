using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IRateService
	{
		Task<CreateResponse<ApiRateResponseModel>> Create(
			ApiRateRequestModel model);

		Task<UpdateResponse<ApiRateResponseModel>> Update(int id,
		                                                   ApiRateRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiRateResponseModel> Get(int id);

		Task<List<ApiRateResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>65d148543ef0672238b395a88acf84c3</Hash>
</Codenesium>*/