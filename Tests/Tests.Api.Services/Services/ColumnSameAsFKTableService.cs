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
			IDALColumnSameAsFKTableMapper dalColumnSameAsFKTableMapper)
			: base(logger,
			       mediator,
			       columnSameAsFKTableRepository,
			       columnSameAsFKTableModelValidator,
			       dalColumnSameAsFKTableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a013fd8ac9bd0ae4c4e7ab4f070e5366</Hash>
</Codenesium>*/