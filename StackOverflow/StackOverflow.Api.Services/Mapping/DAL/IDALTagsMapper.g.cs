using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IDALTagsMapper
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
    <Hash>1820ab85a13677ab274007274dd03cb2</Hash>
</Codenesium>*/