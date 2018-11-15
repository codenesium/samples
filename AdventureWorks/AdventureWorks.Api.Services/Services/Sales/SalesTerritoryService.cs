using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class SalesTerritoryService : AbstractSalesTerritoryService, ISalesTerritoryService
	{
		public SalesTerritoryService(
			ILogger<ISalesTerritoryRepository> logger,
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
    <Hash>1d0d3309d7f471edda16dd2a1a0409e3</Hash>
</Codenesium>*/