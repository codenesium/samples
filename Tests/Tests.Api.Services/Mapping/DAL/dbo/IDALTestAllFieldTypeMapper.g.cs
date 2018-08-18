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
    <Hash>47c311661c5938871dbc13acda22992e</Hash>
</Codenesium>*/