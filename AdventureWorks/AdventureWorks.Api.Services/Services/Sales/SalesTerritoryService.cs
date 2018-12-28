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
			IBOLSalesTerritoryMapper bolSalesTerritoryMapper,
			IDALSalesTerritoryMapper dalSalesTerritoryMapper,
			IBOLCustomerMapper bolCustomerMapper,
			IDALCustomerMapper dalCustomerMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
			IBOLSalesPersonMapper bolSalesPersonMapper,
			IDALSalesPersonMapper dalSalesPersonMapper)
			: base(logger,
			       mediator,
			       salesTerritoryRepository,
			       salesTerritoryModelValidator,
			       bolSalesTerritoryMapper,
			       dalSalesTerritoryMapper,
			       bolCustomerMapper,
			       dalCustomerMapper,
			       bolSalesOrderHeaderMapper,
			       dalSalesOrderHeaderMapper,
			       bolSalesPersonMapper,
			       dalSalesPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9836b39eafe3b89712cef96ea45178b9</Hash>
</Codenesium>*/