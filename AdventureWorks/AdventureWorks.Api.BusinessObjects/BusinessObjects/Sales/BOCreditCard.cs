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
			IApiCreditCardModelValidator creditCardModelValidator)
			: base(logger, creditCardRepository, creditCardModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f713c76bfcf3c9a071e57e32584b77bb</Hash>
</Codenesium>*/