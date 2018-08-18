using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALActionTemplateVersionMapper
	{
		ActionTemplateVersion MapBOToEF(
			BOActionTemplateVersion bo);

		BOActionTemplateVersion MapEFToBO(
			ActionTemplateVersion efActionTemplateVersion);

		List<BOActionTemplateVersion> MapEFToBO(
			List<ActionTemplateVersion> records);
	}
}

/*<Codenesium>
    <Hash>5212bde95ab55d841da1869ec4e523c8</Hash>
</Codenesium>*/