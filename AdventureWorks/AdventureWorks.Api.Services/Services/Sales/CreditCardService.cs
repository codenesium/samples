using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class CreditCardService : AbstractCreditCardService, ICreditCardService
	{
		public CreditCardService(
			ILogger<ICreditCardRepository> logger,
			ICreditCardRepository creditCardRepository,
			IApiCreditCardRequestModelValidator creditCardModelValidator,
			IBOLCreditCardMapper bolcreditCardMapper,
			IDALCreditCardMapper dalcreditCardMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base(logger,
			       creditCardRepository,
			       creditCardModelValidator,
			       bolcreditCardMapper,
			       dalcreditCardMapper,
			       bolSalesOrderHeaderMapper,
			       dalSalesOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ba9c2852d04952439f44eaf5a564f0a7</Hash>
</Codenesium>*/