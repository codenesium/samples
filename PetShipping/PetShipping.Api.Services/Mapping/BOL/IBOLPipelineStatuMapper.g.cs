using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLPipelineStatuMapper
	{
		BOPipelineStatu MapModelToBO(
			int id,
			ApiPipelineStatuRequestModel model);

		ApiPipelineStatuResponseModel MapBOToModel(
			BOPipelineStatu boPipelineStatu);

		List<ApiPipelineStatuResponseModel> MapBOToModel(
			List<BOPipelineStatu> items);
	}
}

/*<Codenesium>
    <Hash>c8f4d9749d086d53b41ae5e54e5c13d6</Hash>
</Codenesium>*/