using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>fb430979460d11118efe180394d48cf5</Hash>
</Codenesium>*/