using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALReleaseMapper
	{
		Release MapBOToEF(
			BORelease bo);

		BORelease MapEFToBO(
			Release efRelease);

		List<BORelease> MapEFToBO(
			List<Release> records);
	}
}

/*<Codenesium>
    <Hash>2e955f2987977b8e7b90fb7e284cccd5</Hash>
</Codenesium>*/