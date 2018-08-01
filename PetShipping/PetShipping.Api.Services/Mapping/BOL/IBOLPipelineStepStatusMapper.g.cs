using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>4b676f31d08776f8053c4bb3a3eba6ab</Hash>
</Codenesium>*/