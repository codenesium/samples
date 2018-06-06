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
			List<BOPipelineStatus> items);
	}
}

/*<Codenesium>
    <Hash>6c65a756c10178dec16f085f47075927</Hash>
</Codenesium>*/