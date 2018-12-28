using MediatR;
using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class ColumnSameAsFKTableService : AbstractColumnSameAsFKTableService, IColumnSameAsFKTableService
	{
		public ColumnSameAsFKTableService(
			ILogger<IColumnSameAsFKTableRepository> logger,
			IMediator mediator,
			IColumnSameAsFKTableRepository columnSameAsFKTableRepository,
			IApiColumnSameAsFKTableServerRequestModelValidator columnSameAsFKTableModelValidator,
			IBOLColumnSameAsFKTableMapper bolColumnSameAsFKTableMapper,
			IDALColumnSameAsFKTableMapper dalColumnSameAsFKTableMapper)
			: base(logger,
			       mediator,
			       columnSameAsFKTableRepository,
			       columnSameAsFKTableModelValidator,
			       bolColumnSameAsFKTableMapper,
			       dalColumnSameAsFKTableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>25ab64e7bd6f575132cca7305be84274</Hash>
</Codenesium>*/