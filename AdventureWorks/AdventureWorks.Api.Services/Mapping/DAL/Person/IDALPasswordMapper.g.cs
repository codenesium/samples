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
    <Hash>b315265c62dd5a6f3682b02b4674d9d8</Hash>
</Codenesium>*/