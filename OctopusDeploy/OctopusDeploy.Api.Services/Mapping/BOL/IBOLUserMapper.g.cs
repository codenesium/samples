using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLUserMapper
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
    <Hash>398260ea416a1542678e652a970c3fa3</Hash>
</Codenesium>*/