using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALTimestampCheckMapper
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
    <Hash>575642a7f86c785b0eb5061497f6f62b</Hash>
</Codenesium>*/