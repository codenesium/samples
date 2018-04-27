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
			ISaleModelValidator saleModelValidator)
			: base(logger, saleRepository, saleModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>4f165e508c1b9de65d3209d1fee2b6d0</Hash>
</Codenesium>*/