using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALOffCapabilityMapper
	{
		OffCapability MapModelToEntity(
			int id,
			ApiOffCapabilityServerRequestModel model);

		ApiOffCapabilityServerResponseModel MapEntityToModel(
			OffCapability item);

		List<ApiOffCapabilityServerResponseModel> MapEntityToModel(
			List<OffCapability> items);
	}
}

/*<Codenesium>
    <Hash>1d7a93f254fcd59bceb08e56ddc840a6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/