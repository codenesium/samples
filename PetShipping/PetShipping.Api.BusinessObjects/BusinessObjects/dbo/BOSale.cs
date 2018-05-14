using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class BOSale:AbstractBOSale, IBOSale
	{
		public BOSale(
			ILogger<SaleRepository> logger,
			ISaleRepository saleRepository,
			IApiSaleModelValidator saleModelValidator)
			: base(logger, saleRepository, saleModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>56b5313d2064858f6ec9b63bf2689d69</Hash>
</Codenesium>*/