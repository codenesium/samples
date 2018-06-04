using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLPipelineMapper
	{
		BOPipeline MapModelToBO(
			int id,
			ApiPipelineRequestModel model);

		ApiPipelineResponseModel MapBOToModel(
			BOPipeline boPipeline);

		List<ApiPipelineResponseModel> MapBOToModel(
			List<BOPipeline> bos);
	}
}

/*<Codenesium>
    <Hash>c705d55dc60a588de92c196248a952e1</Hash>
</Codenesium>*/