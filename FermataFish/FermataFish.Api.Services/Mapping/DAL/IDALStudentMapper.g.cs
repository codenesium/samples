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
    <Hash>4012d56b20d5bf923a3041b00c25970f</Hash>
</Codenesium>*/