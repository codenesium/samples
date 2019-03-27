using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALVehCapabilityMapper
	{
		VehCapability MapModelToEntity(
			int id,
			ApiVehCapabilityServerRequestModel model);

		ApiVehCapabilityServerResponseModel MapEntityToModel(
			VehCapability item);

		List<ApiVehCapabilityServerResponseModel> MapEntityToModel(
			List<VehCapability> items);
	}
}

/*<Codenesium>
    <Hash>a04eb380b080aa8b4dce5e2b0820e6b7</Hash>
</Codenesium>*/