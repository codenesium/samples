using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLPipelineStepMapper
	{
		BOPipelineStep MapModelToBO(
			int id,
			ApiPipelineStepServerRequestModel model);

		ApiPipelineStepServerResponseModel MapBOToModel(
			BOPipelineStep boPipelineStep);

		List<ApiPipelineStepServerResponseModel> MapBOToModel(
			List<BOPipelineStep> items);
	}
}

/*<Codenesium>
    <Hash>4e859b6f4ac67dd164a4e5a4768092bf</Hash>
</Codenesium>*/