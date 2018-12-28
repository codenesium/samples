using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class CreditCardService : AbstractCreditCardService, ICreditCardService
	{
		public CreditCardService(
			ILogger<ICreditCardRepository> logger,
			IMediator mediator,
			ICreditCardRepository creditCardRepository,
			IApiCreditCardServerRequestModelValidator creditCardModelValidator,
			IBOLCreditCardMapper bolCreditCardMapper,
			IDALCreditCardMapper dalCreditCardMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base(logger,
			       mediator,
			       creditCardRepository,
			       creditCardModelValidator,
			       bolCreditCardMapper,
			       dalCreditCardMapper,
			       bolSalesOrderHeaderMapper,
			       dalSalesOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d35a825d733d3d56a0520f479e461b13</Hash>
</Codenesium>*/