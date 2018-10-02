using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLPipelineStepStatuMapper
	{
		BOPipelineStepStatu MapModelToBO(
			int id,
			ApiPipelineStepStatuRequestModel model);

		ApiPipelineStepStatuResponseModel MapBOToModel(
			BOPipelineStepStatu boPipelineStepStatu);

		List<ApiPipelineStepStatuResponseModel> MapBOToModel(
			List<BOPipelineStepStatu> items);
	}
}

/*<Codenesium>
    <Hash>06ce54ee144405967c4b859196a339f5</Hash>
</Codenesium>*/