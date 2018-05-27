using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLPipelineStepNoteMapper
	{
		DTOPipelineStepNote MapModelToDTO(
			int id,
			ApiPipelineStepNoteRequestModel model);

		ApiPipelineStepNoteResponseModel MapDTOToModel(
			DTOPipelineStepNote dtoPipelineStepNote);

		List<ApiPipelineStepNoteResponseModel> MapDTOToModel(
			List<DTOPipelineStepNote> dtos);
	}
}

/*<Codenesium>
    <Hash>96570731aa197bad96eed56af5e1fbd7</Hash>
</Codenesium>*/