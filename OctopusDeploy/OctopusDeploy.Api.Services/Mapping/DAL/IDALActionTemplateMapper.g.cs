using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALActionTemplateMapper
	{
		ActionTemplate MapBOToEF(
			BOActionTemplate bo);

		BOActionTemplate MapEFToBO(
			ActionTemplate efActionTemplate);

		List<BOActionTemplate> MapEFToBO(
			List<ActionTemplate> records);
	}
}

/*<Codenesium>
    <Hash>4bf450e180d66794163208b622cd605b</Hash>
</Codenesium>*/