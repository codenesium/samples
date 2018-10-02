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
	public partial class SaleTicketService : AbstractSaleTicketService, ISaleTicketService
	{
		public SaleTicketService(
			ILogger<ISaleTicketRepository> logger,
			ISaleTicketRepository saleTicketRepository,
			IApiSaleTicketRequestModelValidator saleTicketModelValidator,
			IBOLSaleTicketMapper bolsaleTicketMapper,
			IDALSaleTicketMapper dalsaleTicketMapper
			)
			: base(logger,
			       saleTicketRepository,
			       saleTicketModelValidator,
			       bolsaleTicketMapper,
			       dalsaleTicketMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>06e036694d2fa66be3938f29f6fe8b48</Hash>
</Codenesium>*/