using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class SalesTaxRateService: AbstractSalesTaxRateService, ISalesTaxRateService
	{
		public SalesTaxRateService(
			ILogger<SalesTaxRateRepository> logger,
			ISalesTaxRateRepository salesTaxRateRepository,
			IApiSalesTaxRateRequestModelValidator salesTaxRateModelValidator,
			IBOLSalesTaxRateMapper BOLsalesTaxRateMapper,
			IDALSalesTaxRateMapper DALsalesTaxRateMapper)
			: base(logger, salesTaxRateRepository,
			       salesTaxRateModelValidator,
			       BOLsalesTaxRateMapper,
			       DALsalesTaxRateMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>720f16f0b04c28bc22638dd26f04a5d8</Hash>
</Codenesium>*/