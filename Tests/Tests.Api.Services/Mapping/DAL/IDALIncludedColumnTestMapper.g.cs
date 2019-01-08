using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALIncludedColumnTestMapper
	{
		IncludedColumnTest MapBOToEF(
			BOIncludedColumnTest bo);

		BOIncludedColumnTest MapEFToBO(
			IncludedColumnTest efIncludedColumnTest);

		List<BOIncludedColumnTest> MapEFToBO(
			List<IncludedColumnTest> records);
	}
}

/*<Codenesium>
    <Hash>2c2f4e27fe31c88910310d6a4923dc07</Hash>
</Codenesium>*/