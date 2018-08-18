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
    <Hash>784a8679edf2df1b4fb4bf7f45d97617</Hash>
</Codenesium>*/