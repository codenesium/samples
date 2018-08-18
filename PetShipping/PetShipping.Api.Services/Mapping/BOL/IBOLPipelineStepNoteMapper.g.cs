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
    <Hash>3764c786dd63d2e119a34cae1c02b114</Hash>
</Codenesium>*/