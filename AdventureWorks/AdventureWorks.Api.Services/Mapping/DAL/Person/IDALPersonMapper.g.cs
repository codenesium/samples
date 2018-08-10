using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPersonMapper
	{
		Person MapBOToEF(
			BOPerson bo);

		BOPerson MapEFToBO(
			Person efPerson);

		List<BOPerson> MapEFToBO(
			List<Person> records);
	}
}

/*<Codenesium>
    <Hash>d749136f9d39b1707500926e0bf65b03</Hash>
</Codenesium>*/