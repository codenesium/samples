using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
	public partial class TableRepository : AbstractTableRepository, ITableRepository
	{
		public TableRepository(
			ILogger<TableRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>859751352261ee045ec5c8077af19707</Hash>
</Codenesium>*/