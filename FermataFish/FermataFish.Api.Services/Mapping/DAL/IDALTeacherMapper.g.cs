using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
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
    <Hash>ab72a96cd842d407665bf3f606ee6463</Hash>
</Codenesium>*/