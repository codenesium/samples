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
	public partial class SalesTerritoryHistoryService : AbstractSalesTerritoryHistoryService, ISalesTerritoryHistoryService
	{
		public SalesTerritoryHistoryService(
			ILogger<ISalesTerritoryHistoryRepository> logger,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator,
			IBOLSalesTerritoryHistoryMapper bolsalesTerritoryHistoryMapper,
			IDALSalesTerritoryHistoryMapper dalsalesTerritoryHistoryMapper)
			: base(logger,
			       salesTerritoryHistoryRepository,
			       salesTerritoryHistoryModelValidator,
			       bolsalesTerritoryHistoryMapper,
			       dalsalesTerritoryHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>344a8dedd680c0178be08543f41592c3</Hash>
</Codenesium>*/