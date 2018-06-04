using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
    <Hash>4e7f506f9b11d212faf6d9b89065ce2c</Hash>
</Codenesium>*/