using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>dc8536426bfa6628fc49f9f7ca013a22</Hash>
</Codenesium>*/