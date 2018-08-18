using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALStateProvinceMapper
	{
		StateProvince MapBOToEF(
			BOStateProvince bo);

		BOStateProvince MapEFToBO(
			StateProvince efStateProvince);

		List<BOStateProvince> MapEFToBO(
			List<StateProvince> records);
	}
}

/*<Codenesium>
    <Hash>fc171a3c09ac36f3262d14204da00576</Hash>
</Codenesium>*/