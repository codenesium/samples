using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALTestAllFieldTypeMapper
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
    <Hash>3080451257574bb0656b9acf5f6b7650</Hash>
</Codenesium>*/