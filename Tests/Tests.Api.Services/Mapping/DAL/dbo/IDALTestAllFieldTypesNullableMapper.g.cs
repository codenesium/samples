using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IDALTestAllFieldTypesNullableMapper
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
    <Hash>1082b403f5d19201990fe19e2e85cc3d</Hash>
</Codenesium>*/