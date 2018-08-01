using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALProjectTriggerMapper
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
    <Hash>5db9ee1511751566afc5530ad8cae624</Hash>
</Codenesium>*/