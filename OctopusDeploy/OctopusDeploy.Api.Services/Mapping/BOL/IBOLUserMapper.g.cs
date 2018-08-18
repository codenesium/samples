using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLUserMapper
	{
		BOUser MapModelToBO(
			string id,
			ApiUserRequestModel model);

		ApiUserResponseModel MapBOToModel(
			BOUser boUser);

		List<ApiUserResponseModel> MapBOToModel(
			List<BOUser> items);
	}
}

/*<Codenesium>
    <Hash>3c54d54f85b327dcd3e1b4b0b7748d2e</Hash>
</Codenesium>*/