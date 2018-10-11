using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class SalesTerritoryService : AbstractSalesTerritoryService, ISalesTerritoryService
	{
		public SalesTerritoryService(
			ILogger<ISalesTerritoryRepository> logger,
			ISalesTerritoryRepository salesTerritoryRepository,
			IApiSalesTerritoryRequestModelValidator salesTerritoryModelValidator,
			IBOLSalesTerritoryMapper bolsalesTerritoryMapper,
			IDALSalesTerritoryMapper dalsalesTerritoryMapper,
			IBOLCustomerMapper bolCustomerMapper,
			IDALCustomerMapper dalCustomerMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
			IBOLSalesPersonMapper bolSalesPersonMapper,
			IDALSalesPersonMapper dalSalesPersonMapper,
			IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper,
			IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper)
			: base(logger,
			       salesTerritoryRepository,
			       salesTerritoryModelValidator,
			       bolsalesTerritoryMapper,
			       dalsalesTerritoryMapper,
			       bolCustomerMapper,
			       dalCustomerMapper,
			       bolSalesOrderHeaderMapper,
			       dalSalesOrderHeaderMapper,
			       bolSalesPersonMapper,
			       dalSalesPersonMapper,
			       bolSalesTerritoryHistoryMapper,
			       dalSalesTerritoryHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>91ba437a0d6a67d604e460c9f40de2cd</Hash>
</Codenesium>*/