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
	public partial class EmployeePayHistoryRepository : AbstractEmployeePayHistoryRepository, IEmployeePayHistoryRepository
	{
		public EmployeePayHistoryRepository(
			ILogger<EmployeePayHistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6a65aa58b68c015bb27360ac0ad2c6f6</Hash>
</Codenesium>*/