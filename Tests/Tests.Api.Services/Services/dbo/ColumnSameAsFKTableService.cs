using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class ColumnSameAsFKTableService : AbstractColumnSameAsFKTableService, IColumnSameAsFKTableService
	{
		public ColumnSameAsFKTableService(
			ILogger<IColumnSameAsFKTableRepository> logger,
			IColumnSameAsFKTableRepository columnSameAsFKTableRepository,
			IApiColumnSameAsFKTableServerRequestModelValidator columnSameAsFKTableModelValidator,
			IBOLColumnSameAsFKTableMapper bolColumnSameAsFKTableMapper,
			IDALColumnSameAsFKTableMapper dalColumnSameAsFKTableMapper)
			: base(logger,
			       columnSameAsFKTableRepository,
			       columnSameAsFKTableModelValidator,
			       bolColumnSameAsFKTableMapper,
			       dalColumnSameAsFKTableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e8a483d815c3e5d27b21c1a21e9181a9</Hash>
</Codenesium>*/