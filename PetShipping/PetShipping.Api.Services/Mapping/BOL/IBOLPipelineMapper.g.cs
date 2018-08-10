using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLPipelineMapper
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
    <Hash>b783db41e41e073f71b4f2ae67395b17</Hash>
</Codenesium>*/