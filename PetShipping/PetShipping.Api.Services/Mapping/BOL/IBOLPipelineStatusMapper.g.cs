using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IBOLPipelineStatusMapper
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
    <Hash>4b55ea5d0944c9b5cde4a3b64c61996e</Hash>
</Codenesium>*/