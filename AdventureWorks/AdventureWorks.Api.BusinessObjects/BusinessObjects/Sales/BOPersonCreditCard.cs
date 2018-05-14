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
			IApiPersonCreditCardModelValidator personCreditCardModelValidator)
			: base(logger, personCreditCardRepository, personCreditCardModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>08d7e68fc3783d2e516278ee03b12393</Hash>
</Codenesium>*/