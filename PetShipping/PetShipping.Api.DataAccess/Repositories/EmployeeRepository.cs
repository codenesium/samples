using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>c5fbf9b25bb9defa6744ae1476ef9654</Hash>
</Codenesium>*/