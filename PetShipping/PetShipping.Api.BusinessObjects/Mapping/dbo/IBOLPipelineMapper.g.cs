using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLPipelineMapper
	{
		DTOPipeline MapModelToDTO(
			int id,
			ApiPipelineRequestModel model);

		ApiPipelineResponseModel MapDTOToModel(
			DTOPipeline dtoPipeline);

		List<ApiPipelineResponseModel> MapDTOToModel(
			List<DTOPipeline> dtos);
	}
}

/*<Codenesium>
    <Hash>7086be3643e8145183c114708fc2f8a1</Hash>
</Codenesium>*/