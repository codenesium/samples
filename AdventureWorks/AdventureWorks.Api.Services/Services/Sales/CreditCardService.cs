using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class CreditCardService : AbstractCreditCardService, ICreditCardService
	{
		public CreditCardService(
			ILogger<ICreditCardRepository> logger,
			ICreditCardRepository creditCardRepository,
			IApiCreditCardServerRequestModelValidator creditCardModelValidator,
			IBOLCreditCardMapper bolCreditCardMapper,
			IDALCreditCardMapper dalCreditCardMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base(logger,
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
    <Hash>3e8333be3db891d8eede5d37ba010392</Hash>
</Codenesium>*/