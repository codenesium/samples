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
    <Hash>92b0c43468fa214bf5cb27047c217792</Hash>
</Codenesium>*/