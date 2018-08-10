using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPersonCreditCardMapper
	{
		PersonCreditCard MapBOToEF(
			BOPersonCreditCard bo);

		BOPersonCreditCard MapEFToBO(
			PersonCreditCard efPersonCreditCard);

		List<BOPersonCreditCard> MapEFToBO(
			List<PersonCreditCard> records);
	}
}

/*<Codenesium>
    <Hash>2c8272fa66857835186be3c876b86999</Hash>
</Codenesium>*/