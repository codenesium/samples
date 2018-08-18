using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class DatabaseLogRepository : AbstractDatabaseLogRepository, IDatabaseLogRepository
	{
		public DatabaseLogRepository(
			ILogger<DatabaseLogRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2e237c075692d65d2b058fe3a9203b3c</Hash>
</Codenesium>*/