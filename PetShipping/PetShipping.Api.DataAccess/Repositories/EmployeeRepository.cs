using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public partial class EmployeeRepository : AbstractEmployeeRepository, IEmployeeRepository
	{
		public EmployeeRepository(
			ILogger<EmployeeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8b5f5445c218e1c099b78e644747e6b2</Hash>
</Codenesium>*/