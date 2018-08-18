using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALInterruptionMapper
	{
		Interruption MapBOToEF(
			BOInterruption bo);

		BOInterruption MapEFToBO(
			Interruption efInterruption);

		List<BOInterruption> MapEFToBO(
			List<Interruption> records);
	}
}

/*<Codenesium>
    <Hash>7175713d80ab2e44b38381ddd58d1405</Hash>
</Codenesium>*/