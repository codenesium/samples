using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALStateProvinceMapper
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
    <Hash>0c5d3d67c9116bef88d529afc02b1f93</Hash>
</Codenesium>*/