using MediatR;
using Microsoft.Extensions.Logging;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;

namespace PointOfSaleNS.Api.Services
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
    <Hash>1c38662d73512027986abba1230157a9</Hash>
</Codenesium>*/