using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALDepartmentMapper
	{
		Department MapBOToEF(
			BODepartment bo);

		BODepartment MapEFToBO(
			Department efDepartment);

		List<BODepartment> MapEFToBO(
			List<Department> records);
	}
}

/*<Codenesium>
    <Hash>1717e40c1192be25a415e96f9f6db1b0</Hash>
</Codenesium>*/