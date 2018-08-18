using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALSchemaAPersonMapper
	{
		SchemaAPerson MapBOToEF(
			BOSchemaAPerson bo);

		BOSchemaAPerson MapEFToBO(
			SchemaAPerson efSchemaAPerson);

		List<BOSchemaAPerson> MapEFToBO(
			List<SchemaAPerson> records);
	}
}

/*<Codenesium>
    <Hash>d865802738b5940ef302ed66b0b51ff4</Hash>
</Codenesium>*/