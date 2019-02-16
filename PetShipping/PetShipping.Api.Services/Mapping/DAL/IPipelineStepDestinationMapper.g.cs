using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStepDestinationMapper
	{
		PipelineStepDestination MapModelToEntity(
			int id,
			ApiPipelineStepDestinationServerRequestModel model);

		ApiPipelineStepDestinationServerResponseModel MapEntityToModel(
			PipelineStepDestination item);

		List<ApiPipelineStepDestinationServerResponseModel> MapEntityToModel(
			List<PipelineStepDestination> items);
	}
}

/*<Codenesium>
    <Hash>e293d8eb3c75da4a3e6fc04bb335d8a5</Hash>
</Codenesium>*/