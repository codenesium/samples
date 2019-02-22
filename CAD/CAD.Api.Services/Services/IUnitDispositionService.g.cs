using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IUnitDispositionService
	{
		Task<CreateResponse<ApiUnitDispositionServerResponseModel>> Create(
			ApiUnitDispositionServerRequestModel model);

		Task<UpdateResponse<ApiUnitDispositionServerResponseModel>> Update(int id,
		                                                                    ApiUnitDispositionServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiUnitDispositionServerResponseModel> Get(int id);

		Task<List<ApiUnitDispositionServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>4b394bce63b002a39fd242844d3a3d12</Hash>
</Codenesium>*/