using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALProjectTriggerMapper
	{
		ProjectTrigger MapBOToEF(
			BOProjectTrigger bo);

		BOProjectTrigger MapEFToBO(
			ProjectTrigger efProjectTrigger);

		List<BOProjectTrigger> MapEFToBO(
			List<ProjectTrigger> records);
	}
}

/*<Codenesium>
    <Hash>ca7c46e894ba512e8178ed21a37d03ab</Hash>
</Codenesium>*/