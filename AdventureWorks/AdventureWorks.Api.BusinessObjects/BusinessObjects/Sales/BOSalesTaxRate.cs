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
			ISalesTaxRateModelValidator salesTaxRateModelValidator)
			: base(logger, salesTaxRateRepository, salesTaxRateModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>893b553fc023c62814d00e7f73321554</Hash>
</Codenesium>*/