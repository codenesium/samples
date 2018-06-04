using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALPasswordMapper
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
    <Hash>c7bc2cd02ad31881e9965a181a8f0653</Hash>
</Codenesium>*/