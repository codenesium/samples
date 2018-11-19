using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>198a1879b7a80fc90a09a0d87d15fff4</Hash>
</Codenesium>*/