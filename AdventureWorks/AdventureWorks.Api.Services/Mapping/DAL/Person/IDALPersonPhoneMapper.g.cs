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
    <Hash>290407df14ef4c434477438babf7daae</Hash>
</Codenesium>*/