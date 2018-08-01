using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALDepartmentMapper
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
    <Hash>f1e6802756daf4da6eaca465e9bc832b</Hash>
</Codenesium>*/