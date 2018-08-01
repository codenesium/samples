using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IDALSchemaAPersonMapper
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
    <Hash>7778c9593ed8fb61b19686270a145ecc</Hash>
</Codenesium>*/