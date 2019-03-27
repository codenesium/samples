using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALOfficerCapabilitiesMapper
	{
		OfficerCapabilities MapModelToEntity(
			int id,
			ApiOfficerCapabilitiesServerRequestModel model);

		ApiOfficerCapabilitiesServerResponseModel MapEntityToModel(
			OfficerCapabilities item);

		List<ApiOfficerCapabilitiesServerResponseModel> MapEntityToModel(
			List<OfficerCapabilities> items);
	}
}

/*<Codenesium>
    <Hash>345e047dab3cfdef7b6be0c90a0aeef7</Hash>
</Codenesium>*/