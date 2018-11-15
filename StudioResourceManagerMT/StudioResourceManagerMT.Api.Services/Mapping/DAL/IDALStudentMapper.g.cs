using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>b9f70113ac0a34f2cdafc191d7cda81c</Hash>
</Codenesium>*/