using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLUserRoleMapper
	{
		BOUserRole MapModelToBO(
			string id,
			ApiUserRoleRequestModel model);

		ApiUserRoleResponseModel MapBOToModel(
			BOUserRole boUserRole);

		List<ApiUserRoleResponseModel> MapBOToModel(
			List<BOUserRole> items);
	}
}

/*<Codenesium>
    <Hash>ee9ce6a64f761c1b0dc47c2f3f5040d2</Hash>
</Codenesium>*/