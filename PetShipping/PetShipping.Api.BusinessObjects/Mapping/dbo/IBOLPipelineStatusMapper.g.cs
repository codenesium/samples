using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLPipelineStatusMapper
	{
		DTOPipelineStatus MapModelToDTO(
			int id,
			ApiPipelineStatusRequestModel model);

		ApiPipelineStatusResponseModel MapDTOToModel(
			DTOPipelineStatus dtoPipelineStatus);

		List<ApiPipelineStatusResponseModel> MapDTOToModel(
			List<DTOPipelineStatus> dtos);
	}
}

/*<Codenesium>
    <Hash>5b0ac6e5b1554314e49314f73b9f09e8</Hash>
</Codenesium>*/