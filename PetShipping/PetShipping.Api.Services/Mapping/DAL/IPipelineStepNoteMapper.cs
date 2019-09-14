using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStepNoteMapper
	{
		PipelineStepNote MapModelToEntity(
			int id,
			ApiPipelineStepNoteServerRequestModel model);

		ApiPipelineStepNoteServerResponseModel MapEntityToModel(
			PipelineStepNote item);

		List<ApiPipelineStepNoteServerResponseModel> MapEntityToModel(
			List<PipelineStepNote> items);
	}
}

/*<Codenesium>
    <Hash>a54c0580f17bfd8735593ed5bedd301a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/