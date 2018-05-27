using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLHandlerPipelineStepMapper
	{
		DTOHandlerPipelineStep MapModelToDTO(
			int id,
			ApiHandlerPipelineStepRequestModel model);

		ApiHandlerPipelineStepResponseModel MapDTOToModel(
			DTOHandlerPipelineStep dtoHandlerPipelineStep);

		List<ApiHandlerPipelineStepResponseModel> MapDTOToModel(
			List<DTOHandlerPipelineStep> dtos);
	}
}

/*<Codenesium>
    <Hash>7a3ce4c703b7bccad4848a2b4351c1aa</Hash>
</Codenesium>*/