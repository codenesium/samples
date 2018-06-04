using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class EmployeePayHistoryRepository: AbstractEmployeePayHistoryRepository, IEmployeePayHistoryRepository
	{
		public EmployeePayHistoryRepository(
			ILogger<EmployeePayHistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>abfccd3ae7308b12f9717cd6646f05d2</Hash>
</Codenesium>*/