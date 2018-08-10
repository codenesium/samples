using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class SaleService : AbstractSaleService, ISaleService
	{
		public SaleService(
			ILogger<ISaleRepository> logger,
			ISaleRepository saleRepository,
			IApiSaleRequestModelValidator saleModelValidator,
			IBOLSaleMapper bolsaleMapper,
			IDALSaleMapper dalsaleMapper,
			IBOLSaleTicketsMapper bolSaleTicketsMapper,
			IDALSaleTicketsMapper dalSaleTicketsMapper
			)
			: base(logger,
			       saleRepository,
			       saleModelValidator,
			       bolsaleMapper,
			       dalsaleMapper,
			       bolSaleTicketsMapper,
			       dalSaleTicketsMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b2ece807906737e39d3581c298ea59f5</Hash>
</Codenesium>*/