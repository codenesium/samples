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
	public partial class SpecialOfferProductService : AbstractSpecialOfferProductService, ISpecialOfferProductService
	{
		public SpecialOfferProductService(
			ILogger<ISpecialOfferProductRepository> logger,
			ISpecialOfferProductRepository specialOfferProductRepository,
			IApiSpecialOfferProductRequestModelValidator specialOfferProductModelValidator,
			IBOLSpecialOfferProductMapper bolspecialOfferProductMapper,
			IDALSpecialOfferProductMapper dalspecialOfferProductMapper,
			IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper,
			IDALSalesOrderDetailMapper dalSalesOrderDetailMapper
			)
			: base(logger,
			       specialOfferProductRepository,
			       specialOfferProductModelValidator,
			       bolspecialOfferProductMapper,
			       dalspecialOfferProductMapper,
			       bolSalesOrderDetailMapper,
			       dalSalesOrderDetailMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9d56112935a7d678db3ce4ee6efffc1d</Hash>
</Codenesium>*/