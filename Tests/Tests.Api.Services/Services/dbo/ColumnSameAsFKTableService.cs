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
			IDALColumnSameAsFKTableMapper dalcolumnSameAsFKTableMapper
			)
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
    <Hash>239c91367ee472999f985a78c99c55f1</Hash>
</Codenesium>*/