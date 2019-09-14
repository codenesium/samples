using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStatusMapper
	{
		PipelineStatus MapModelToEntity(
			int id,
			ApiPipelineStatusServerRequestModel model);

		ApiPipelineStatusServerResponseModel MapEntityToModel(
			PipelineStatus item);

		List<ApiPipelineStatusServerResponseModel> MapEntityToModel(
			List<PipelineStatus> items);
	}
}

/*<Codenesium>
    <Hash>7469310ce0135f409bcb9403403974cf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/