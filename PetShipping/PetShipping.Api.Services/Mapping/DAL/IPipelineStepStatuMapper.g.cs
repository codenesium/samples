using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStepStatuMapper
	{
		PipelineStepStatu MapModelToEntity(
			int id,
			ApiPipelineStepStatuServerRequestModel model);

		ApiPipelineStepStatuServerResponseModel MapEntityToModel(
			PipelineStepStatu item);

		List<ApiPipelineStepStatuServerResponseModel> MapEntityToModel(
			List<PipelineStepStatu> items);
	}
}

/*<Codenesium>
    <Hash>8de8a5eccc8e4c369092098b0cf94180</Hash>
</Codenesium>*/