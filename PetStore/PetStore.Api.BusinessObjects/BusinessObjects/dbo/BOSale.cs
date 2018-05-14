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
			IApiSaleModelValidator saleModelValidator)
			: base(logger, saleRepository, saleModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>0bb36d13af0a3f18b2a16d5fc00a0ddf</Hash>
</Codenesium>*/