using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLInvitationMapper
	{
		BOInvitation MapModelToBO(
			string id,
			ApiInvitationRequestModel model);

		ApiInvitationResponseModel MapBOToModel(
			BOInvitation boInvitation);

		List<ApiInvitationResponseModel> MapBOToModel(
			List<BOInvitation> items);
	}
}

/*<Codenesium>
    <Hash>ba50b14795b1ebc2c730889c4336de19</Hash>
</Codenesium>*/