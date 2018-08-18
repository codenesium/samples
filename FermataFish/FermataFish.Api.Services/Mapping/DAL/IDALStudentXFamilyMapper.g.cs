using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IDALStudentXFamilyMapper
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
    <Hash>f28d93a07b906852d9debcfb2aebe583</Hash>
</Codenesium>*/