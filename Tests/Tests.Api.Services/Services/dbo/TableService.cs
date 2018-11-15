using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class TableService : AbstractTableService, ITableService
	{
		public TableService(
			ILogger<ITableRepository> logger,
			ITableRepository tableRepository,
			IApiTableServerRequestModelValidator tableModelValidator,
			IBOLTableMapper bolTableMapper,
			IDALTableMapper dalTableMapper)
			: base(logger,
			       tableRepository,
			       tableModelValidator,
			       bolTableMapper,
			       dalTableMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4197417e06fc56fb288499853bcc8633</Hash>
</Codenesium>*/