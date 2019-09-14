using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStepStatusMapper
	{
		PipelineStepStatus MapModelToEntity(
			int id,
			ApiPipelineStepStatusServerRequestModel model);

		ApiPipelineStepStatusServerResponseModel MapEntityToModel(
			PipelineStepStatus item);

		List<ApiPipelineStepStatusServerResponseModel> MapEntityToModel(
			List<PipelineStepStatus> items);
	}
}

/*<Codenesium>
    <Hash>f2baea36e0aeb4634f4319660fbae106</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/