using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class SaleService: AbstractSaleService, ISaleService
	{
		public SaleService(
			ILogger<SaleRepository> logger,
			ISaleRepository saleRepository,
			IApiSaleRequestModelValidator saleModelValidator,
			IBOLSaleMapper BOLsaleMapper,
			IDALSaleMapper DALsaleMapper)
			: base(logger, saleRepository,
			       saleModelValidator,
			       BOLsaleMapper,
			       DALsaleMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>7ad3bb2a0074dd13127a0ee452c83ed6</Hash>
</Codenesium>*/