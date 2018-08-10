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
    <Hash>ff0f269e37e086a6cde6ca398f94bdbc</Hash>
</Codenesium>*/