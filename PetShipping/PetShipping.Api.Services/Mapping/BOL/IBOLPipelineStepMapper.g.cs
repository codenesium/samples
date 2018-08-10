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
    <Hash>96088a4e9b155aa7cf1b595122e8ba81</Hash>
</Codenesium>*/