using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLPipelineStepMapper
	{
		DTOPipelineStep MapModelToDTO(
			int id,
			ApiPipelineStepRequestModel model);

		ApiPipelineStepResponseModel MapDTOToModel(
			DTOPipelineStep dtoPipelineStep);

		List<ApiPipelineStepResponseModel> MapDTOToModel(
			List<DTOPipelineStep> dtos);
	}
}

/*<Codenesium>
    <Hash>c5b2024e12e6522dc7996729b7062e5a</Hash>
</Codenesium>*/