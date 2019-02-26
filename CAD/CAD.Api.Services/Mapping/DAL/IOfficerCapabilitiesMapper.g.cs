using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALOfficerCapabilitiesMapper
	{
		OfficerCapabilities MapModelToEntity(
			int capabilityId,
			ApiOfficerCapabilitiesServerRequestModel model);

		ApiOfficerCapabilitiesServerResponseModel MapEntityToModel(
			OfficerCapabilities item);

		List<ApiOfficerCapabilitiesServerResponseModel> MapEntityToModel(
			List<OfficerCapabilities> items);
	}
}

/*<Codenesium>
    <Hash>a7248658343a6120302f229767514b87</Hash>
</Codenesium>*/