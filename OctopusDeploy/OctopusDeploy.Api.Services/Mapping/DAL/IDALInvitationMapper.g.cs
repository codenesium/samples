using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALInvitationMapper
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
    <Hash>4006ce6b3d858dfe03ccc4302f680ef4</Hash>
</Codenesium>*/