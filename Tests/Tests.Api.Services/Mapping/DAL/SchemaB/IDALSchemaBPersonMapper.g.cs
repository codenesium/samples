using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IDALSchemaBPersonMapper
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
    <Hash>63a23858e6c19e78d92b58013511bf5f</Hash>
</Codenesium>*/