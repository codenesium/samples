using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class SalesTaxRateRepository : AbstractSalesTaxRateRepository, ISalesTaxRateRepository
	{
		public SalesTaxRateRepository(
			ILogger<SalesTaxRateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f34328c6e149e89cdf8de02dd08b6a43</Hash>
</Codenesium>*/