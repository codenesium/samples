using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALEventTeacherMapper
	{
		EventTeacher MapBOToEF(
			BOEventTeacher bo);

		BOEventTeacher MapEFToBO(
			EventTeacher efEventTeacher);

		List<BOEventTeacher> MapEFToBO(
			List<EventTeacher> records);
	}
}

/*<Codenesium>
    <Hash>d7500d1be9c16cb17a999760b2d53a51</Hash>
</Codenesium>*/