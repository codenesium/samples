using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class DatabaseLogRepository: AbstractDatabaseLogRepository, IDatabaseLogRepository
	{
		public DatabaseLogRepository(
			IDALDatabaseLogMapper mapper,
			ILogger<DatabaseLogRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c11dd38264b6c548a33ce770fe63604e</Hash>
</Codenesium>*/