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
			List<BOPipelineStepNote> items);
	}
}

/*<Codenesium>
    <Hash>3b776ba0f9c52ea37677dc888e2420fd</Hash>
</Codenesium>*/