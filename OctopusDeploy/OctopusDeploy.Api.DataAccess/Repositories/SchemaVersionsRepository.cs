using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>cb84993b007ad1972f5ff0df078892c4</Hash>
</Codenesium>*/