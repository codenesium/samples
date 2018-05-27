using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public class BOSale:AbstractBOSale, IBOSale
	{
		public BOSale(
			ILogger<SaleRepository> logger,
			ISaleRepository saleRepository,
			IApiSaleRequestModelValidator saleModelValidator,
			IBOLSaleMapper saleMapper)
			: base(logger, saleRepository, saleModelValidator, saleMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>bf41532454a3798a0e1585513a389f43</Hash>
</Codenesium>*/