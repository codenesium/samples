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
    <Hash>e3f7ee9cc55fba137ad0e0691668410f</Hash>
</Codenesium>*/