using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLPipelineMapper
	{
		BOPipeline MapModelToBO(
			int id,
			ApiPipelineRequestModel model);

		ApiPipelineResponseModel MapBOToModel(
			BOPipeline boPipeline);

		List<ApiPipelineResponseModel> MapBOToModel(
			List<BOPipeline> items);
	}
}

/*<Codenesium>
    <Hash>1d1cd81a24cc5ba7d886f7ec3b69520b</Hash>
</Codenesium>*/