using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
			List<BOPipelineStatus> bos);
	}
}

/*<Codenesium>
    <Hash>bc76826f415f37ac9980d0e72689ce06</Hash>
</Codenesium>*/