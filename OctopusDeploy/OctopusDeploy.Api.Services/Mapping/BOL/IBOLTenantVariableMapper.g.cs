using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLTenantVariableMapper
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
    <Hash>85446d37250e564e7f36e4404daf8d7b</Hash>
</Codenesium>*/