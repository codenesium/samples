using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCreditCardMapper
	{
		CreditCard MapBOToEF(
			BOCreditCard bo);

		BOCreditCard MapEFToBO(
			CreditCard efCreditCard);

		List<BOCreditCard> MapEFToBO(
			List<CreditCard> records);
	}
}

/*<Codenesium>
    <Hash>c89f985dc9eed5f583793ff5533ed6db</Hash>
</Codenesium>*/