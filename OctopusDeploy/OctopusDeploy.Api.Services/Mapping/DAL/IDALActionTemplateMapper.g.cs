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
    <Hash>336d05c3a4b54322973a707d583eb79c</Hash>
</Codenesium>*/