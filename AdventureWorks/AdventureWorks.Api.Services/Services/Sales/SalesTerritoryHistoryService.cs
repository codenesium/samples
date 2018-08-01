using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class SalesTerritoryHistoryService : AbstractSalesTerritoryHistoryService, ISalesTerritoryHistoryService
	{
		public SalesTerritoryHistoryService(
			ILogger<ISalesTerritoryHistoryRepository> logger,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator,
			IBOLSalesTerritoryHistoryMapper bolsalesTerritoryHistoryMapper,
			IDALSalesTerritoryHistoryMapper dalsalesTerritoryHistoryMapper
			)
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
    <Hash>6ee43a92ee7f6f36b3cbf1d1d59239a1</Hash>
</Codenesium>*/