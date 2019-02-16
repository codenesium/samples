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
	public partial class ColumnSameAsFKTableRepository : AbstractColumnSameAsFKTableRepository, IColumnSameAsFKTableRepository
	{
		public ColumnSameAsFKTableRepository(
			ILogger<ColumnSameAsFKTableRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{

		}
	}
}

/*<Codenesium>
    <Hash>7936c30faeb2f4f4882f161395bd1718</Hash>
</Codenesium>*/