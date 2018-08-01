using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class SchemaVersionsRepository : AbstractSchemaVersionsRepository, ISchemaVersionsRepository
	{
		public SchemaVersionsRepository(
			ILogger<SchemaVersionsRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e7206e7098ef935f2c3e9d89e0c12aee</Hash>
</Codenesium>*/