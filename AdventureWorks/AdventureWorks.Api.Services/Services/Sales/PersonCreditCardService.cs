using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class PersonCreditCardService : AbstractPersonCreditCardService, IPersonCreditCardService
	{
		public PersonCreditCardService(
			ILogger<IPersonCreditCardRepository> logger,
			IPersonCreditCardRepository personCreditCardRepository,
			IApiPersonCreditCardRequestModelValidator personCreditCardModelValidator,
			IBOLPersonCreditCardMapper bolpersonCreditCardMapper,
			IDALPersonCreditCardMapper dalpersonCreditCardMapper
			)
			: base(logger,
			       personCreditCardRepository,
			       personCreditCardModelValidator,
			       bolpersonCreditCardMapper,
			       dalpersonCreditCardMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ce5e48b34d4dc6f99804cf1c356d1744</Hash>
</Codenesium>*/