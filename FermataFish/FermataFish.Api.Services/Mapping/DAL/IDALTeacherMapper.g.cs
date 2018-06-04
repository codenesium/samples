using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
    <Hash>94b2a030cbf808130ac8a835160ad044</Hash>
</Codenesium>*/