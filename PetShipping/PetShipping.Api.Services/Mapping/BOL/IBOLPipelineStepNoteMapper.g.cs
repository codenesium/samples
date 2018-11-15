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
			ApiPipelineStepNoteServerRequestModel model);

		ApiPipelineStepNoteServerResponseModel MapBOToModel(
			BOPipelineStepNote boPipelineStepNote);

		List<ApiPipelineStepNoteServerResponseModel> MapBOToModel(
			List<BOPipelineStepNote> items);
	}
}

/*<Codenesium>
    <Hash>6d8ebf91d1c76496e7ec4d0e7089cb5d</Hash>
</Codenesium>*/