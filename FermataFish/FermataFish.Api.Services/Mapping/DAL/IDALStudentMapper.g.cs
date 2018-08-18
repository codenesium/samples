using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
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
    <Hash>f10fb18c58c0724cf2735b5cd91fd6ad</Hash>
</Codenesium>*/