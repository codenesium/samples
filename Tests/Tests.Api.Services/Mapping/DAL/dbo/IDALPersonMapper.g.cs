using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
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
    <Hash>308f2d568494df7cd7f67716444b4395</Hash>
</Codenesium>*/