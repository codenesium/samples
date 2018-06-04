using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class EmployeeRepository: AbstractEmployeeRepository, IEmployeeRepository
	{
		public EmployeeRepository(
			ILogger<EmployeeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>38613f0337c339ab596beae9b4ed5d3b</Hash>
</Codenesium>*/