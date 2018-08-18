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
    <Hash>ae48fcbd6363d0f8933025e7b606df00</Hash>
</Codenesium>*/