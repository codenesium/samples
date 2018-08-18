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
    <Hash>1094a8f8e80ccb185c9ac4e8065658f6</Hash>
</Codenesium>*/