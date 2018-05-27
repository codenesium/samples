using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOSalesTaxRate: AbstractBOSalesTaxRate, IBOSalesTaxRate
	{
		public BOSalesTaxRate(
			ILogger<SalesTaxRateRepository> logger,
			ISalesTaxRateRepository salesTaxRateRepository,
			IApiSalesTaxRateRequestModelValidator salesTaxRateModelValidator,
			IBOLSalesTaxRateMapper salesTaxRateMapper)
			: base(logger, salesTaxRateRepository, salesTaxRateModelValidator, salesTaxRateMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>09d79d360fd31f8f9f0405d48f2e92ff</Hash>
</Codenesium>*/