using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLTenantVariableMapper
	{
		BOTenantVariable MapModelToBO(
			string id,
			ApiTenantVariableRequestModel model);

		ApiTenantVariableResponseModel MapBOToModel(
			BOTenantVariable boTenantVariable);

		List<ApiTenantVariableResponseModel> MapBOToModel(
			List<BOTenantVariable> items);
	}
}

/*<Codenesium>
    <Hash>0718a126d175683f85cc82c80dd8115d</Hash>
</Codenesium>*/