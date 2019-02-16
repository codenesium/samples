using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class SaleTicketService : AbstractSaleTicketService, ISaleTicketService
	{
		public SaleTicketService(
			ILogger<ISaleTicketRepository> logger,
			IMediator mediator,
			ISaleTicketRepository saleTicketRepository,
			IApiSaleTicketServerRequestModelValidator saleTicketModelValidator,
			IDALSaleTicketMapper dalSaleTicketMapper)
			: base(logger,
			       mediator,
			       saleTicketRepository,
			       saleTicketModelValidator,
			       dalSaleTicketMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ee7ea97d7919520a32a4567b28cb1185</Hash>
</Codenesium>*/