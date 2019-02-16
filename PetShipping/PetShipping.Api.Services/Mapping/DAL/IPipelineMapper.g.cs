using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineMapper
	{
		Pipeline MapModelToEntity(
			int id,
			ApiPipelineServerRequestModel model);

		ApiPipelineServerResponseModel MapEntityToModel(
			Pipeline item);

		List<ApiPipelineServerResponseModel> MapEntityToModel(
			List<Pipeline> items);
	}
}

/*<Codenesium>
    <Hash>fe6694f1266ae67ef11677e4071601dd</Hash>
</Codenesium>*/