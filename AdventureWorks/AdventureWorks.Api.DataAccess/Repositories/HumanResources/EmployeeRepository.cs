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
    <Hash>596558f10d8fd14476944854e38a1342</Hash>
</Codenesium>*/