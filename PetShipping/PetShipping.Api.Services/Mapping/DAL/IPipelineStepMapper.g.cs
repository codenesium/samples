using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStepMapper
	{
		PipelineStep MapModelToEntity(
			int id,
			ApiPipelineStepServerRequestModel model);

		ApiPipelineStepServerResponseModel MapEntityToModel(
			PipelineStep item);

		List<ApiPipelineStepServerResponseModel> MapEntityToModel(
			List<PipelineStep> items);
	}
}

/*<Codenesium>
    <Hash>a1b5108a031ad276ab8923bd6612676d</Hash>
</Codenesium>*/