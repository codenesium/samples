using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALPersonPhoneMapper
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
    <Hash>86f93811b0ff33e99a264d4a812d22e1</Hash>
</Codenesium>*/