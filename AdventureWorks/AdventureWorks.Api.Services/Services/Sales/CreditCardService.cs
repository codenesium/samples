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
			IDALCreditCardMapper dalCreditCardMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base(logger,
			       mediator,
			       creditCardRepository,
			       creditCardModelValidator,
			       dalCreditCardMapper,
			       dalSalesOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6969c82eaa7a7bbaa7d4e72c5d7662b6</Hash>
</Codenesium>*/