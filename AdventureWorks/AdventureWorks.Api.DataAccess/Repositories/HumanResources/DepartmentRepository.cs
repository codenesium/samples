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
			IDALDepartmentMapper mapper,
			ILogger<DepartmentRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>fcda8fe1f432f27cd3695b9d0ae71993</Hash>
</Codenesium>*/