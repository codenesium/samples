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
			IDALSaleTicketMapper dalSaleTicketMapper)
			: base(logger,
			       mediator,
			       saleRepository,
			       saleModelValidator,
			       dalSaleMapper,
			       dalSaleTicketMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1ca24adec0e41b83a30b2c0a86b2c0ac</Hash>
</Codenesium>*/