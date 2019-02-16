using MediatR;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
    <Hash>dd7d07294389f6f1bb8132abc34605f7</Hash>
</Codenesium>*/