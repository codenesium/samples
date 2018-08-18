using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPersonPhoneMapper
	{
		PersonPhone MapBOToEF(
			BOPersonPhone bo);

		BOPersonPhone MapEFToBO(
			PersonPhone efPersonPhone);

		List<BOPersonPhone> MapEFToBO(
			List<PersonPhone> records);
	}
}

/*<Codenesium>
    <Hash>267e03943681cfed28edaebf097f543b</Hash>
</Codenesium>*/