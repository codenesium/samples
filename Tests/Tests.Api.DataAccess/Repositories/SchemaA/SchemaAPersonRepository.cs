using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
	public partial class SchemaAPersonRepository : AbstractSchemaAPersonRepository, ISchemaAPersonRepository
	{
		public SchemaAPersonRepository(
			ILogger<SchemaAPersonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>253dd935b3605ec11e7317f59e9d720a</Hash>
</Codenesium>*/