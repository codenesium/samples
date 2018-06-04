using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class CreditCardService: AbstractCreditCardService, ICreditCardService
	{
		public CreditCardService(
			ILogger<CreditCardRepository> logger,
			ICreditCardRepository creditCardRepository,
			IApiCreditCardRequestModelValidator creditCardModelValidator,
			IBOLCreditCardMapper BOLcreditCardMapper,
			IDALCreditCardMapper DALcreditCardMapper)
			: base(logger, creditCardRepository,
			       creditCardModelValidator,
			       BOLcreditCardMapper,
			       DALcreditCardMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>f1831290e0398dcb9f92e5ef507b8f17</Hash>
</Codenesium>*/