using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStatuMapper
	{
		PipelineStatu MapModelToEntity(
			int id,
			ApiPipelineStatuServerRequestModel model);

		ApiPipelineStatuServerResponseModel MapEntityToModel(
			PipelineStatu item);

		List<ApiPipelineStatuServerResponseModel> MapEntityToModel(
			List<PipelineStatu> items);
	}
}

/*<Codenesium>
    <Hash>b2ac6121b2dd2cff89a7632c5a5b3576</Hash>
</Codenesium>*/