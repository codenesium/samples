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
    <Hash>09cfd3fb2513cd2736073eae50354eb7</Hash>
</Codenesium>*/