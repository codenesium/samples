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
    <Hash>1e7924be57275786853aefb2ac52b444</Hash>
</Codenesium>*/