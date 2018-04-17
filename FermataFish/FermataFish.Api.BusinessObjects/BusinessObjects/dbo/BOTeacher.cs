using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class BOTeacher: AbstractBOTeacher, IBOTeacher
	{
		public BOTeacher(
			ILogger<TeacherRepository> logger,
			ITeacherRepository teacherRepository,
			ITeacherModelValidator teacherModelValidator)
			: base(logger, teacherRepository, teacherModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>9361a1f5e35c17973d2d7c63d998e704</Hash>
</Codenesium>*/