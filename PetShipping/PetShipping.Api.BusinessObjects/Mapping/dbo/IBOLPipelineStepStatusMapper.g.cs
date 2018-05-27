using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLPipelineStepStatusMapper
	{
		DTOPipelineStepStatus MapModelToDTO(
			int id,
			ApiPipelineStepStatusRequestModel model);

		ApiPipelineStepStatusResponseModel MapDTOToModel(
			DTOPipelineStepStatus dtoPipelineStepStatus);

		List<ApiPipelineStepStatusResponseModel> MapDTOToModel(
			List<DTOPipelineStepStatus> dtos);
	}
}

/*<Codenesium>
    <Hash>7b8f1e1b88a0a283dd530fe04c559b4f</Hash>
</Codenesium>*/