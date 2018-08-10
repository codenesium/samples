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
	public partial class SalesPersonService : AbstractSalesPersonService, ISalesPersonService
	{
		public SalesPersonService(
			ILogger<ISalesPersonRepository> logger,
			ISalesPersonRepository salesPersonRepository,
			IApiSalesPersonRequestModelValidator salesPersonModelValidator,
			IBOLSalesPersonMapper bolsalesPersonMapper,
			IDALSalesPersonMapper dalsalesPersonMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
			IBOLSalesPersonQuotaHistoryMapper bolSalesPersonQuotaHistoryMapper,
			IDALSalesPersonQuotaHistoryMapper dalSalesPersonQuotaHistoryMapper,
			IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper,
			IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper,
			IBOLStoreMapper bolStoreMapper,
			IDALStoreMapper dalStoreMapper
			)
			: base(logger,
			       salesPersonRepository,
			       salesPersonModelValidator,
			       bolsalesPersonMapper,
			       dalsalesPersonMapper,
			       bolSalesOrderHeaderMapper,
			       dalSalesOrderHeaderMapper,
			       bolSalesPersonQuotaHistoryMapper,
			       dalSalesPersonQuotaHistoryMapper,
			       bolSalesTerritoryHistoryMapper,
			       dalSalesTerritoryHistoryMapper,
			       bolStoreMapper,
			       dalStoreMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4ee4b19ae87f127e7e949f77041cd5e1</Hash>
</Codenesium>*/