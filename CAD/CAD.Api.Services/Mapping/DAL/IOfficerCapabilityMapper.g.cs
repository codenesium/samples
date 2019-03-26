using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALOfficerCapabilityMapper
	{
		OfficerCapability MapModelToEntity(
			int capabilityId,
			ApiOfficerCapabilityServerRequestModel model);

		ApiOfficerCapabilityServerResponseModel MapEntityToModel(
			OfficerCapability item);

		List<ApiOfficerCapabilityServerResponseModel> MapEntityToModel(
			List<OfficerCapability> items);
	}
}

/*<Codenesium>
    <Hash>2dc0249808eb16e45d69056defec93f9</Hash>
</Codenesium>*/