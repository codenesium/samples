using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class DatabaseLogRepository: AbstractDatabaseLogRepository, IDatabaseLogRepository
	{
		public DatabaseLogRepository(
			ILogger<DatabaseLogRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>65c61dab2bbd6dad7c8c11305536a56d</Hash>
</Codenesium>*/