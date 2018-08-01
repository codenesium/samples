using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IStateService
	{
		Task<CreateResponse<ApiStateResponseModel>> Create(
			ApiStateRequestModel model);

		Task<UpdateResponse<ApiStateResponseModel>> Update(int id,
		                                                    ApiStateRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStateResponseModel> Get(int id);

		Task<List<ApiStateResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudioResponseModel>> Studios(int stateId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>65b31c48b29bb2fce240a870a90a5511</Hash>
</Codenesium>*/