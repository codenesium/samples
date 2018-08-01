using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IDALTimestampCheckMapper
	{
		TimestampCheck MapBOToEF(
			BOTimestampCheck bo);

		BOTimestampCheck MapEFToBO(
			TimestampCheck efTimestampCheck);

		List<BOTimestampCheck> MapEFToBO(
			List<TimestampCheck> records);
	}
}

/*<Codenesium>
    <Hash>06fb9e482e2d2eebea2dd91a69d00f60</Hash>
</Codenesium>*/