using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>ca769301b7d8a68dfaf5475b00e533ee</Hash>
</Codenesium>*/