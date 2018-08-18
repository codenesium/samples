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
    <Hash>9e320bc32e3b2ca8efaf57b9438ec6fd</Hash>
</Codenesium>*/