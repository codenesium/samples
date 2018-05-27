using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOCreditCard: AbstractBOCreditCard, IBOCreditCard
	{
		public BOCreditCard(
			ILogger<CreditCardRepository> logger,
			ICreditCardRepository creditCardRepository,
			IApiCreditCardRequestModelValidator creditCardModelValidator,
			IBOLCreditCardMapper creditCardMapper)
			: base(logger, creditCardRepository, creditCardModelValidator, creditCardMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>b258cec76d2e0c1012f5a2fa2f4009d9</Hash>
</Codenesium>*/