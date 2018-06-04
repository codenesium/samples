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
			List<BOPipelineStepStatus> bos);
	}
}

/*<Codenesium>
    <Hash>d14d347d6bc3fb826f1383e16959838e</Hash>
</Codenesium>*/