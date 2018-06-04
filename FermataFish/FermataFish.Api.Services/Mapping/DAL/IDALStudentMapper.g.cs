using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IDALStudentMapper
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
    <Hash>f2182db2eb5cc27324fb69a7484e1372</Hash>
</Codenesium>*/