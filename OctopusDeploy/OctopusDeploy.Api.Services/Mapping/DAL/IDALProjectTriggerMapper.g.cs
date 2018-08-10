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
    <Hash>55687fbb3e7114b883d98a4aee09f09e</Hash>
</Codenesium>*/