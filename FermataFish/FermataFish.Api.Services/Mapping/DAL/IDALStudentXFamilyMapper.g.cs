using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IDALStudentXFamilyMapper
	{
		StudentXFamily MapBOToEF(
			BOStudentXFamily bo);

		BOStudentXFamily MapEFToBO(
			StudentXFamily efStudentXFamily);

		List<BOStudentXFamily> MapEFToBO(
			List<StudentXFamily> records);
	}
}

/*<Codenesium>
    <Hash>cff31c8941d33e5a68d83a5b6b09d298</Hash>
</Codenesium>*/