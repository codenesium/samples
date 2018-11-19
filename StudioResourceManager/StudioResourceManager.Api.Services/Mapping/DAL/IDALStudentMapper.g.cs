using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALStudentMapper
	{
		Student MapBOToEF(
			BOStudent bo);

		BOStudent MapEFToBO(
			Student efStudent);

		List<BOStudent> MapEFToBO(
			List<Student> records);
	}
}

/*<Codenesium>
    <Hash>bdf6b70fffd188804c5e90ac89e6d4c1</Hash>
</Codenesium>*/