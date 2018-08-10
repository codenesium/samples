using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLTenantMapper
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
    <Hash>b5ce9df5ecc0ec2f35c56d8316a3fbe5</Hash>
</Codenesium>*/