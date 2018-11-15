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
			ApiPipelineServerRequestModel model);

		ApiPipelineServerResponseModel MapBOToModel(
			BOPipeline boPipeline);

		List<ApiPipelineServerResponseModel> MapBOToModel(
			List<BOPipeline> items);
	}
}

/*<Codenesium>
    <Hash>de7d8caf91e9c371916f28700ba92437</Hash>
</Codenesium>*/