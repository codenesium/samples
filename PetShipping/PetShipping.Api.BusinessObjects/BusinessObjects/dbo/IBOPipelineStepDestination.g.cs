using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStepDestination
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
    <Hash>5e5c84ce39bf3d7c1390db331396fa76</Hash>
</Codenesium>*/