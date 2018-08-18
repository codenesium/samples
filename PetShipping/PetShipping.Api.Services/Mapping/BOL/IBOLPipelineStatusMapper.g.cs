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
    <Hash>a27b6a1f05d7aa16f828cdba878f21e9</Hash>
</Codenesium>*/