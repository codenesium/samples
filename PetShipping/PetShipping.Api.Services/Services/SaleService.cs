using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class SaleService : AbstractSaleService, ISaleService
	{
		public SaleService(
			ILogger<ISaleRepository> logger,
			IMediator mediator,
			ISaleRepository saleRepository,
			IApiSaleServerRequestModelValidator saleModelValidator,
			IDALSaleMapper dalSaleMapper)
			: base(logger,
			       mediator,
			       saleRepository,
			       saleModelValidator,
			       dalSaleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b18bc59be8309bd72d1b8273d5ede794</Hash>
</Codenesium>*/