using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLPipelineStepNoteMapper
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
    <Hash>a9cbbc7b41e94db6663ba56f4868e12a</Hash>
</Codenesium>*/