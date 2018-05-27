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
			IApiTeacherRequestModelValidator teacherModelValidator,
			IBOLTeacherMapper teacherMapper)
			: base(logger, teacherRepository, teacherModelValidator, teacherMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>8537530723ed52d704b92c4b5e361a85</Hash>
</Codenesium>*/