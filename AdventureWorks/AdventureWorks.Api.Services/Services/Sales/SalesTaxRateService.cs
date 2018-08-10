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
	public partial class SalesTaxRateService : AbstractSalesTaxRateService, ISalesTaxRateService
	{
		public SalesTaxRateService(
			ILogger<ISalesTaxRateRepository> logger,
			ISalesTaxRateRepository salesTaxRateRepository,
			IApiSalesTaxRateRequestModelValidator salesTaxRateModelValidator,
			IBOLSalesTaxRateMapper bolsalesTaxRateMapper,
			IDALSalesTaxRateMapper dalsalesTaxRateMapper
			)
			: base(logger,
			       salesTaxRateRepository,
			       salesTaxRateModelValidator,
			       bolsalesTaxRateMapper,
			       dalsalesTaxRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5656040fa779ee9df43f71cfab1b572f</Hash>
</Codenesium>*/