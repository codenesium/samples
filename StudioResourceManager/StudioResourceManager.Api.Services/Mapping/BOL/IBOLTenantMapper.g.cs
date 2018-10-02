using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLTenantMapper
	{
		BOTenant MapModelToBO(
			int id,
			ApiTenantRequestModel model);

		ApiTenantResponseModel MapBOToModel(
			BOTenant boTenant);

		List<ApiTenantResponseModel> MapBOToModel(
			List<BOTenant> items);
	}
}

/*<Codenesium>
    <Hash>2475d6a80ea39414bc16208439ec89ce</Hash>
</Codenesium>*/