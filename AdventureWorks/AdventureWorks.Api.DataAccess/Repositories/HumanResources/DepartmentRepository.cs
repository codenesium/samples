using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class DepartmentRepository: AbstractDepartmentRepository, IDepartmentRepository
	{
		public DepartmentRepository(
			IObjectMapper mapper,
			ILogger<DepartmentRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>1f25709038f304358737959dc5846848</Hash>
</Codenesium>*/