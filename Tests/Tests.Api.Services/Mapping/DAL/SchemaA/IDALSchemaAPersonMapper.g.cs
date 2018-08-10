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
    <Hash>813b7e4a3f83cdb98bacad1298fd4a59</Hash>
</Codenesium>*/