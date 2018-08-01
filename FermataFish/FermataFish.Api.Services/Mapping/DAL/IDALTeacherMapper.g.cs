using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IDALTeacherMapper
	{
		Teacher MapBOToEF(
			BOTeacher bo);

		BOTeacher MapEFToBO(
			Teacher efTeacher);

		List<BOTeacher> MapEFToBO(
			List<Teacher> records);
	}
}

/*<Codenesium>
    <Hash>e6fe8c358554d24853819e5f96340ea4</Hash>
</Codenesium>*/