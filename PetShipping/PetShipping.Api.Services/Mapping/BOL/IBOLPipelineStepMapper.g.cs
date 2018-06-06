using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLPipelineStepMapper
	{
		BOPipelineStep MapModelToBO(
			int id,
			ApiPipelineStepRequestModel model);

		ApiPipelineStepResponseModel MapBOToModel(
			BOPipelineStep boPipelineStep);

		List<ApiPipelineStepResponseModel> MapBOToModel(
			List<BOPipelineStep> items);
	}
}

/*<Codenesium>
    <Hash>8bbb7688f3f691fda0f319c627001455</Hash>
</Codenesium>*/