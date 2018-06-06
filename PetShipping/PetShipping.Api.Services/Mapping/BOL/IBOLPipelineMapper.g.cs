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
			List<BOPipeline> items);
	}
}

/*<Codenesium>
    <Hash>7693a9d78ac91002d7a8479d60e42058</Hash>
</Codenesium>*/