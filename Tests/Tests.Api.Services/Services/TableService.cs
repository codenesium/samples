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
			IDALTableMapper dalTableMapper)
			: base(logger,
			       mediator,
			       tableRepository,
			       tableModelValidator,
			       dalTableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>917291d3498656b61b95c135060d18b0</Hash>
</Codenesium>*/