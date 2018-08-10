using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLPipelineStepStatusMapper
	{
		BOPipelineStepStatus MapModelToBO(
			int id,
			ApiPipelineStepStatusRequestModel model);

		ApiPipelineStepStatusResponseModel MapBOToModel(
			BOPipelineStepStatus boPipelineStepStatus);

		List<ApiPipelineStepStatusResponseModel> MapBOToModel(
			List<BOPipelineStepStatus> items);
	}
}

/*<Codenesium>
    <Hash>3e7019c4511545e50ca37c6260338a9a</Hash>
</Codenesium>*/