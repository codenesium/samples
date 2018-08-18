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
    <Hash>d333a4f25ef28fccab3663a85188d5a6</Hash>
</Codenesium>*/