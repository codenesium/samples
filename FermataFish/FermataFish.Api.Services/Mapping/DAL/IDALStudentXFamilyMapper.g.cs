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
    <Hash>8dbc2f71a60949fe9bd592c8b6d581ed</Hash>
</Codenesium>*/