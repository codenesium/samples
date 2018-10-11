using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial class SaleService : AbstractSaleService, ISaleService
	{
		public SaleService(
			ILogger<ISaleRepository> logger,
			ISaleRepository saleRepository,
			IApiSaleRequestModelValidator saleModelValidator,
			IBOLSaleMapper bolsaleMapper,
			IDALSaleMapper dalsaleMapper)
			: base(logger,
			       saleRepository,
			       saleModelValidator,
			       bolsaleMapper,
			       dalsaleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f18a1ed6237250f7cf1e9789811efd38</Hash>
</Codenesium>*/