using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALActionTemplateVersionMapper
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
    <Hash>4405b1021f5f6919ba7afe413e587772</Hash>
</Codenesium>*/