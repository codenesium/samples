using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class SalesOrderHeaderService : AbstractSalesOrderHeaderService, ISalesOrderHeaderService
	{
		public SalesOrderHeaderService(
			ILogger<ISalesOrderHeaderRepository> logger,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			IApiSalesOrderHeaderServerRequestModelValidator salesOrderHeaderModelValidator,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base(logger,
			       salesOrderHeaderRepository,
			       salesOrderHeaderModelValidator,
			       bolSalesOrderHeaderMapper,
			       dalSalesOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fa3dce4ebe29b9b88d59ed6ce6fc0ad9</Hash>
</Codenesium>*/