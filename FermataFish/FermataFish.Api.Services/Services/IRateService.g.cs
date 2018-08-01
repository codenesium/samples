using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IRateService
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
    <Hash>1db8a3d7e1c958d84568c620703e9932</Hash>
</Codenesium>*/