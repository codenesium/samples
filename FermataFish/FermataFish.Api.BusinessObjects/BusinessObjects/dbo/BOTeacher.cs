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
			IApiTeacherModelValidator teacherModelValidator)
			: base(logger, teacherRepository, teacherModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f99afa108701026d9f3d6abc35af133b</Hash>
</Codenesium>*/