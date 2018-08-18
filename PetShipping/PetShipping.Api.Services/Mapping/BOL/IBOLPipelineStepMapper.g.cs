using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLPipelineStepMapper
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
    <Hash>d4e219f1906f7129de975e5b007d8382</Hash>
</Codenesium>*/