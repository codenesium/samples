using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface IPipelineStepDestinationService
	{
		Task<CreateResponse<ApiPipelineStepDestinationResponseModel>> Create(
			ApiPipelineStepDestinationRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineStepDestinationRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepDestinationResponseModel> Get(int id);

		Task<List<ApiPipelineStepDestinationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5c29bb7234325e2f09e36c5a9bf27cef</Hash>
</Codenesium>*/