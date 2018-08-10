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
    <Hash>3470a1df160cd803d7ee3e2e3e382ca4</Hash>
</Codenesium>*/