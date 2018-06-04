using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public class SaleService: AbstractSaleService, ISaleService
	{
		public SaleService(
			ILogger<SaleRepository> logger,
			ISaleRepository saleRepository,
			IApiSaleRequestModelValidator saleModelValidator,
			IBOLSaleMapper BOLsaleMapper,
			IDALSaleMapper DALsaleMapper)
			: base(logger, saleRepository,
			       saleModelValidator,
			       BOLsaleMapper,
			       DALsaleMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>9e8a84df36b949548649d496108f3881</Hash>
</Codenesium>*/