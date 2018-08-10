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
    <Hash>70affbbaad315d88b2eb5ea43ffba6cf</Hash>
</Codenesium>*/