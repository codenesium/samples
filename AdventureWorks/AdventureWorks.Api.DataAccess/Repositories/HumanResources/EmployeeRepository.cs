using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
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
    <Hash>ae1b4028ed436dc7ab76f55392d097b2</Hash>
</Codenesium>*/