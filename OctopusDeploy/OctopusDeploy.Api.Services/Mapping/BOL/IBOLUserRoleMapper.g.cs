using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLUserRoleMapper
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
    <Hash>810b5a0bef67296f5795d5d4f50105bf</Hash>
</Codenesium>*/