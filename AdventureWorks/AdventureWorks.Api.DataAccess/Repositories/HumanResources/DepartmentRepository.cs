using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class DepartmentRepository : AbstractDepartmentRepository, IDepartmentRepository
	{
		public DepartmentRepository(
			ILogger<DepartmentRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>30c69035c5367ccf35c7ce3463e2a5a6</Hash>
</Codenesium>*/