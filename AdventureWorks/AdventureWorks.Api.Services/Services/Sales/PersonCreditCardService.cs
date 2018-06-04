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
	public class PersonCreditCardService: AbstractPersonCreditCardService, IPersonCreditCardService
	{
		public PersonCreditCardService(
			ILogger<PersonCreditCardRepository> logger,
			IPersonCreditCardRepository personCreditCardRepository,
			IApiPersonCreditCardRequestModelValidator personCreditCardModelValidator,
			IBOLPersonCreditCardMapper BOLpersonCreditCardMapper,
			IDALPersonCreditCardMapper DALpersonCreditCardMapper)
			: base(logger, personCreditCardRepository,
			       personCreditCardModelValidator,
			       BOLpersonCreditCardMapper,
			       DALpersonCreditCardMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>df6c751c03fb40b4c657f9d46777f7bc</Hash>
</Codenesium>*/