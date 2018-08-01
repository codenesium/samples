using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class SchemaAPersonService : AbstractSchemaAPersonService, ISchemaAPersonService
	{
		public SchemaAPersonService(
			ILogger<ISchemaAPersonRepository> logger,
			ISchemaAPersonRepository schemaAPersonRepository,
			IApiSchemaAPersonRequestModelValidator schemaAPersonModelValidator,
			IBOLSchemaAPersonMapper bolschemaAPersonMapper,
			IDALSchemaAPersonMapper dalschemaAPersonMapper
			)
			: base(logger,
			       schemaAPersonRepository,
			       schemaAPersonModelValidator,
			       bolschemaAPersonMapper,
			       dalschemaAPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>94800811caf741417314c000c46ebeeb</Hash>
</Codenesium>*/