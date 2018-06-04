using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class SalesTaxRateRepository: AbstractSalesTaxRateRepository, ISalesTaxRateRepository
	{
		public SalesTaxRateRepository(
			ILogger<SalesTaxRateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>493786bd68b9677bcdc42d38298486b5</Hash>
</Codenesium>*/