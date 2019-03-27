using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class SaleTicketsService : AbstractSaleTicketsService, ISaleTicketsService
	{
		public SaleTicketsService(
			ILogger<ISaleTicketsRepository> logger,
			IMediator mediator,
			ISaleTicketsRepository saleTicketsRepository,
			IApiSaleTicketsServerRequestModelValidator saleTicketsModelValidator,
			IDALSaleTicketsMapper dalSaleTicketsMapper)
			: base(logger,
			       mediator,
			       saleTicketsRepository,
			       saleTicketsModelValidator,
			       dalSaleTicketsMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>21fc76f88533b780a5f195c7fccfc9c2</Hash>
</Codenesium>*/