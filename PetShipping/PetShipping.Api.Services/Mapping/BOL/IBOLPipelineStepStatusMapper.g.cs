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
    <Hash>373cd3d1ccb749a5cac7749d15021bb2</Hash>
</Codenesium>*/