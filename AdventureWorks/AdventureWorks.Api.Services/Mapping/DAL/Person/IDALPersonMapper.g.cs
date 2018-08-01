using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALPersonMapper
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
    <Hash>a8cacc90d7a7621f1d75d46fd26f800a</Hash>
</Codenesium>*/