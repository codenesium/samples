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
			ISaleModelValidator saleModelValidator)
			: base(logger, saleRepository, saleModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>8914e3220bb7ef3d5328d8698b7a6737</Hash>
</Codenesium>*/