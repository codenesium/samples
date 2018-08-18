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
    <Hash>4497416f6304da58e69f70ad95afc46d</Hash>
</Codenesium>*/