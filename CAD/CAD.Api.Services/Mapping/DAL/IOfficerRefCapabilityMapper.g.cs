using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALOfficerRefCapabilityMapper
	{
		OfficerRefCapability MapModelToEntity(
			int id,
			ApiOfficerRefCapabilityServerRequestModel model);

		ApiOfficerRefCapabilityServerResponseModel MapEntityToModel(
			OfficerRefCapability item);

		List<ApiOfficerRefCapabilityServerResponseModel> MapEntityToModel(
			List<OfficerRefCapability> items);
	}
}

/*<Codenesium>
    <Hash>bd7160595044729ecb03a87221ef2b96</Hash>
</Codenesium>*/