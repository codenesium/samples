using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALInvitationMapper
	{
		Invitation MapBOToEF(
			BOInvitation bo);

		BOInvitation MapEFToBO(
			Invitation efInvitation);

		List<BOInvitation> MapEFToBO(
			List<Invitation> records);
	}
}

/*<Codenesium>
    <Hash>06aa347948f94c5fbdf865c6a77375bf</Hash>
</Codenesium>*/