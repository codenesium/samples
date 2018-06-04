using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLPipelineStepNoteMapper
	{
		BOPipelineStepNote MapModelToBO(
			int id,
			ApiPipelineStepNoteRequestModel model);

		ApiPipelineStepNoteResponseModel MapBOToModel(
			BOPipelineStepNote boPipelineStepNote);

		List<ApiPipelineStepNoteResponseModel> MapBOToModel(
			List<BOPipelineStepNote> bos);
	}
}

/*<Codenesium>
    <Hash>ade19413be5075e2e7de1d12d95f0d04</Hash>
</Codenesium>*/