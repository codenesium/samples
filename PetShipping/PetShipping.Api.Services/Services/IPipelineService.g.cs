using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineService
	{
		Task<CreateResponse<ApiPipelineResponseModel>> Create(
			ApiPipelineRequestModel model);

		Task<UpdateResponse<ApiPipelineResponseModel>> Update(int id,
		                                                       ApiPipelineRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineResponseModel> Get(int id);

		Task<List<ApiPipelineResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>75e0ffc02f88ceb83bda3f2b0774bbee</Hash>
</Codenesium>*/