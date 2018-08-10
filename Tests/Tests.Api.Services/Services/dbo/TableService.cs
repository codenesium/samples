using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class TableService : AbstractTableService, ITableService
	{
		public TableService(
			ILogger<ITableRepository> logger,
			ITableRepository tableRepository,
			IApiTableRequestModelValidator tableModelValidator,
			IBOLTableMapper boltableMapper,
			IDALTableMapper daltableMapper
			)
			: base(logger,
			       tableRepository,
			       tableModelValidator,
			       boltableMapper,
			       daltableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>67a2ab84b3b169f23a2548ca3ab4b24b</Hash>
</Codenesium>*/