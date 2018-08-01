using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
			List<BOPipelineStepNote> items);
	}
}

/*<Codenesium>
    <Hash>f5d7b0985f7e53572f753523f6d0c5dc</Hash>
</Codenesium>*/