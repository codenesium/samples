using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLInvitationMapper
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
    <Hash>51a1f0d535dd67c7b1e4540433110fbd</Hash>
</Codenesium>*/