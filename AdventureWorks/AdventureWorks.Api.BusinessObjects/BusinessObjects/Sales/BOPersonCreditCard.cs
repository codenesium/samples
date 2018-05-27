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
	public class BOPersonCreditCard: AbstractBOPersonCreditCard, IBOPersonCreditCard
	{
		public BOPersonCreditCard(
			ILogger<PersonCreditCardRepository> logger,
			IPersonCreditCardRepository personCreditCardRepository,
			IApiPersonCreditCardRequestModelValidator personCreditCardModelValidator,
			IBOLPersonCreditCardMapper personCreditCardMapper)
			: base(logger, personCreditCardRepository, personCreditCardModelValidator, personCreditCardMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>8d325604bcd56229bf0e2140fa83b0b0</Hash>
</Codenesium>*/