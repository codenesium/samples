using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLPipelineStepStatusMapper
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
    <Hash>5f440af19117a53fa1244b0e56abc2e2</Hash>
</Codenesium>*/