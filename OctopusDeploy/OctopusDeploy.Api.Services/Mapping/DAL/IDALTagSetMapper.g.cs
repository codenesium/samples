using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALTagSetMapper
	{
		TagSet MapBOToEF(
			BOTagSet bo);

		BOTagSet MapEFToBO(
			TagSet efTagSet);

		List<BOTagSet> MapEFToBO(
			List<TagSet> records);
	}
}

/*<Codenesium>
    <Hash>e53f8918959692fd3bd5ae3920b7d220</Hash>
</Codenesium>*/