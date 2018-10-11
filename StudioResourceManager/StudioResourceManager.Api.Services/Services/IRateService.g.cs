using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>5c97b023f4647b4c14c9cd6627efe270</Hash>
</Codenesium>*/