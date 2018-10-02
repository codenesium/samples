using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALEventStudentMapper
	{
		EventStudent MapBOToEF(
			BOEventStudent bo);

		BOEventStudent MapEFToBO(
			EventStudent efEventStudent);

		List<BOEventStudent> MapEFToBO(
			List<EventStudent> records);
	}
}

/*<Codenesium>
    <Hash>5556a42ed08fe00f55573ae0e1d17e99</Hash>
</Codenesium>*/