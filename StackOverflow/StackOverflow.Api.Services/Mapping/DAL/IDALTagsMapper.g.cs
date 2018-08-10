using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALTagsMapper
	{
		Tags MapBOToEF(
			BOTags bo);

		BOTags MapEFToBO(
			Tags efTags);

		List<BOTags> MapEFToBO(
			List<Tags> records);
	}
}

/*<Codenesium>
    <Hash>69ac708326500c20cd17cf293106711c</Hash>
</Codenesium>*/