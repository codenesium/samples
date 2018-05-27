using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLPipelineStepDestinationMapper
	{
		DTOPipelineStepDestination MapModelToDTO(
			int id,
			ApiPipelineStepDestinationRequestModel model);

		ApiPipelineStepDestinationResponseModel MapDTOToModel(
			DTOPipelineStepDestination dtoPipelineStepDestination);

		List<ApiPipelineStepDestinationResponseModel> MapDTOToModel(
			List<DTOPipelineStepDestination> dtos);
	}
}

/*<Codenesium>
    <Hash>71825e9f6434143095bef265166c4a63</Hash>
</Codenesium>*/