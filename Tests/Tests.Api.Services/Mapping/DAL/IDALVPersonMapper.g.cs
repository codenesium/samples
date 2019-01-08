using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALVPersonMapper
	{
		VPerson MapBOToEF(
			BOVPerson bo);

		BOVPerson MapEFToBO(
			VPerson efVPerson);

		List<BOVPerson> MapEFToBO(
			List<VPerson> records);
	}
}

/*<Codenesium>
    <Hash>578267d0de4caed0c16cc9ef3af84425</Hash>
</Codenesium>*/