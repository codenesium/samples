using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALOfficerCapabilityMapper
	{
		OfficerCapability MapModelToEntity(
			int id,
			ApiOfficerCapabilityServerRequestModel model);

		ApiOfficerCapabilityServerResponseModel MapEntityToModel(
			OfficerCapability item);

		List<ApiOfficerCapabilityServerResponseModel> MapEntityToModel(
			List<OfficerCapability> items);
	}
}

/*<Codenesium>
    <Hash>73a71b37442690f17c2fe792922fa6f2</Hash>
</Codenesium>*/