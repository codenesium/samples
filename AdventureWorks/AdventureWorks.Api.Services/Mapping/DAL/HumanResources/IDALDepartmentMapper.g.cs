using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>0b09f1740e56daa8945fc2ac2054a352</Hash>
</Codenesium>*/