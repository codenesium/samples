using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class SalesTerritoryService : AbstractSalesTerritoryService, ISalesTerritoryService
	{
		public SalesTerritoryService(
			ILogger<ISalesTerritoryRepository> logger,
			IMediator mediator,
			ISalesTerritoryRepository salesTerritoryRepository,
			IApiSalesTerritoryServerRequestModelValidator salesTerritoryModelValidator,
			IDALSalesTerritoryMapper dalSalesTerritoryMapper,
			IDALCustomerMapper dalCustomerMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
			IDALSalesPersonMapper dalSalesPersonMapper)
			: base(logger,
			       mediator,
			       salesTerritoryRepository,
			       salesTerritoryModelValidator,
			       dalSalesTerritoryMapper,
			       dalCustomerMapper,
			       dalSalesOrderHeaderMapper,
			       dalSalesPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c68f148102ea20ee44c80baf56d3bb82</Hash>
</Codenesium>*/