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
    <Hash>e700239a8537bc459661c3a10cc7e0ab</Hash>
</Codenesium>*/