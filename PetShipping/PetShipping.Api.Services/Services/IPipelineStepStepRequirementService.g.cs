using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStepStepRequirementService
	{
		Task<CreateResponse<ApiPipelineStepStepRequirementResponseModel>> Create(
			ApiPipelineStepStepRequirementRequestModel model);

		Task<UpdateResponse<ApiPipelineStepStepRequirementResponseModel>> Update(int id,
		                                                                          ApiPipelineStepStepRequirementRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepStepRequirementResponseModel> Get(int id);

		Task<List<ApiPipelineStepStepRequirementResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9e05205adee5a44a06f90b619f80e41b</Hash>
</Codenesium>*/