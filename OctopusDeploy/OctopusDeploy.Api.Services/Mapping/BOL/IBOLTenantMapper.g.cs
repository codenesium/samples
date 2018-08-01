using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLTenantMapper
	{
		BOTenant MapModelToBO(
			string id,
			ApiTenantRequestModel model);

		ApiTenantResponseModel MapBOToModel(
			BOTenant boTenant);

		List<ApiTenantResponseModel> MapBOToModel(
			List<BOTenant> items);
	}
}

/*<Codenesium>
    <Hash>4e227caf834794c6913d945f707e2883</Hash>
</Codenesium>*/