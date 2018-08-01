using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALTagSetMapper
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
    <Hash>c386652123b8f740ed06ae4082f46019</Hash>
</Codenesium>*/