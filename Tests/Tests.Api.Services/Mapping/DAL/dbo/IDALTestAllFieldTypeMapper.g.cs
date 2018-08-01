using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IDALTestAllFieldTypeMapper
	{
		TestAllFieldType MapBOToEF(
			BOTestAllFieldType bo);

		BOTestAllFieldType MapEFToBO(
			TestAllFieldType efTestAllFieldType);

		List<BOTestAllFieldType> MapEFToBO(
			List<TestAllFieldType> records);
	}
}

/*<Codenesium>
    <Hash>a83c716cd4b27ab67d2c1eca5a664998</Hash>
</Codenesium>*/