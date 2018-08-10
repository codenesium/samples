using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALActionTemplateMapper
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
    <Hash>691e7d92ec65151237791ce4cf62e3b9</Hash>
</Codenesium>*/