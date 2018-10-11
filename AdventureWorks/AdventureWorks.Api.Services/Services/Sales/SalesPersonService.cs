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
			IDALStoreMapper dalStoreMapper)
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
    <Hash>e0f54d26f6a14045ec10b4e6009cb056</Hash>
</Codenesium>*/