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
    <Hash>b1e6b1b82e251057d6a01599bbdd0a4d</Hash>
</Codenesium>*/