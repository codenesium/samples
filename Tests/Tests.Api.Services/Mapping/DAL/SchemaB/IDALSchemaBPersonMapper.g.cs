using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALSchemaBPersonMapper
	{
		SchemaBPerson MapBOToEF(
			BOSchemaBPerson bo);

		BOSchemaBPerson MapEFToBO(
			SchemaBPerson efSchemaBPerson);

		List<BOSchemaBPerson> MapEFToBO(
			List<SchemaBPerson> records);
	}
}

/*<Codenesium>
    <Hash>0fcfcdb581fffff85be765ffba63e518</Hash>
</Codenesium>*/