using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPasswordMapper
	{
		Password MapBOToEF(
			BOPassword bo);

		BOPassword MapEFToBO(
			Password efPassword);

		List<BOPassword> MapEFToBO(
			List<Password> records);
	}
}

/*<Codenesium>
    <Hash>6368e45cb6ccce2ad5a720fbacf68b4b</Hash>
</Codenesium>*/