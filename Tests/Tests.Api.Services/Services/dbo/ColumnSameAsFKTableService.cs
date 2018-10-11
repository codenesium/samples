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
	public partial class ColumnSameAsFKTableService : AbstractColumnSameAsFKTableService, IColumnSameAsFKTableService
	{
		public ColumnSameAsFKTableService(
			ILogger<IColumnSameAsFKTableRepository> logger,
			IColumnSameAsFKTableRepository columnSameAsFKTableRepository,
			IApiColumnSameAsFKTableRequestModelValidator columnSameAsFKTableModelValidator,
			IBOLColumnSameAsFKTableMapper bolcolumnSameAsFKTableMapper,
			IDALColumnSameAsFKTableMapper dalcolumnSameAsFKTableMapper)
			: base(logger,
			       columnSameAsFKTableRepository,
			       columnSameAsFKTableModelValidator,
			       bolcolumnSameAsFKTableMapper,
			       dalcolumnSameAsFKTableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>05b1c102ed51854b969476d7273a335b</Hash>
</Codenesium>*/