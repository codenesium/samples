using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALTestAllFieldTypesNullableMapper
	{
		TestAllFieldTypesNullable MapBOToEF(
			BOTestAllFieldTypesNullable bo);

		BOTestAllFieldTypesNullable MapEFToBO(
			TestAllFieldTypesNullable efTestAllFieldTypesNullable);

		List<BOTestAllFieldTypesNullable> MapEFToBO(
			List<TestAllFieldTypesNullable> records);
	}
}

/*<Codenesium>
    <Hash>e82c6b6886b6af4ff2dfd62f5c973cb7</Hash>
</Codenesium>*/