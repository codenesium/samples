using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLPipelineStatusMapper
	{
		BOPipelineStatus MapModelToBO(
			int id,
			ApiPipelineStatusRequestModel model);

		ApiPipelineStatusResponseModel MapBOToModel(
			BOPipelineStatus boPipelineStatus);

		List<ApiPipelineStatusResponseModel> MapBOToModel(
			List<BOPipelineStatus> items);
	}
}

/*<Codenesium>
    <Hash>b8930678a276f4c3ee87075dcea17beb</Hash>
</Codenesium>*/