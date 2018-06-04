using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class DepartmentRepository: AbstractDepartmentRepository, IDepartmentRepository
	{
		public DepartmentRepository(
			ILogger<DepartmentRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>9471e559c750682d53a8ed2d600e3413</Hash>
</Codenesium>*/