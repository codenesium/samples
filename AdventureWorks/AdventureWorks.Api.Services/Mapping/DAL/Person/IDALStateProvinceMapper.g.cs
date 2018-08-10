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
    <Hash>2ff4fb968dc3f24af27d44c2725bb9a9</Hash>
</Codenesium>*/