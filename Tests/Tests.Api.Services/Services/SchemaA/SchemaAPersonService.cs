using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
			IDALSchemaAPersonMapper dalschemaAPersonMapper)
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
    <Hash>de955e80fa64cd3e4c5308bb4c08a367</Hash>
</Codenesium>*/