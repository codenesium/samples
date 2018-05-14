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
	public class EmployeeRepository: AbstractEmployeeRepository, IEmployeeRepository
	{
		public EmployeeRepository(
			IObjectMapper mapper,
			ILogger<EmployeeRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>11bde51bacd165a3c276fd88eb525514</Hash>
</Codenesium>*/