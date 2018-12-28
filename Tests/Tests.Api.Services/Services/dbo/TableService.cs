using MediatR;
using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class TableService : AbstractTableService, ITableService
	{
		public TableService(
			ILogger<ITableRepository> logger,
			IMediator mediator,
			ITableRepository tableRepository,
			IApiTableServerRequestModelValidator tableModelValidator,
			IBOLTableMapper bolTableMapper,
			IDALTableMapper dalTableMapper)
			: base(logger,
			       mediator,
			       tableRepository,
			       tableModelValidator,
			       bolTableMapper,
			       dalTableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e9df6997605d9f6656a5ef0f30c9be11</Hash>
</Codenesium>*/