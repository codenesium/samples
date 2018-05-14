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
			IObjectMapper mapper,
			ILogger<DatabaseLogRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>721799bec07c249e0bb29c4a411d9ea2</Hash>
</Codenesium>*/