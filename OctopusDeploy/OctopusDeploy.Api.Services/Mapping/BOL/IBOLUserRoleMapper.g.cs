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
    <Hash>a0c3787850ffb9fd696e362a4157fe54</Hash>
</Codenesium>*/