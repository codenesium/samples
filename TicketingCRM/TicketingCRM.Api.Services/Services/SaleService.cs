using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class SaleService : AbstractSaleService, ISaleService
	{
		public SaleService(
			ILogger<ISaleRepository> logger,
			IMediator mediator,
			ISaleRepository saleRepository,
			IApiSaleServerRequestModelValidator saleModelValidator,
			IDALSaleMapper dalSaleMapper,
			IDALSaleTicketsMapper dalSaleTicketsMapper)
			: base(logger,
			       mediator,
			       saleRepository,
			       saleModelValidator,
			       dalSaleMapper,
			       dalSaleTicketsMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>042da8d8f6db83c5f96e8ffdd2e97eb3</Hash>
</Codenesium>*/