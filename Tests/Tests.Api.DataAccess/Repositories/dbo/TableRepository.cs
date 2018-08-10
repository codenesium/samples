using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>faa0a702e4eab929aaa2af5a12ca7da7</Hash>
</Codenesium>*/