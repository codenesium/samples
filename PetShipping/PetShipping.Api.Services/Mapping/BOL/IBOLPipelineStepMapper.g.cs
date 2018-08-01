using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>f6552cca39b7e91f42bf40e6b1b37074</Hash>
</Codenesium>*/