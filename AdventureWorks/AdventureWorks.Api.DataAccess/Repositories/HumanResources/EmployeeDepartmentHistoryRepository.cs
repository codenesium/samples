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
	public partial class EmployeeDepartmentHistoryRepository : AbstractEmployeeDepartmentHistoryRepository, IEmployeeDepartmentHistoryRepository
	{
		public EmployeeDepartmentHistoryRepository(
			ILogger<EmployeeDepartmentHistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8e4eab69b6a86b6d9c2becbf3fc8d29b</Hash>
</Codenesium>*/