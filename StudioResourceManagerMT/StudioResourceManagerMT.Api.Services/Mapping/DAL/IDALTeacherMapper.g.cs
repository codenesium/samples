using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALTeacherMapper
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
    <Hash>885183c91821c2fd14c8432693c913c4</Hash>
</Codenesium>*/