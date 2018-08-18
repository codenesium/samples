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
    <Hash>1c47384e523c3ee68e9665ea29b9fef1</Hash>
</Codenesium>*/