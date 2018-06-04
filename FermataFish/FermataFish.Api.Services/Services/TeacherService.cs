using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class TeacherService: AbstractTeacherService, ITeacherService
	{
		public TeacherService(
			ILogger<TeacherRepository> logger,
			ITeacherRepository teacherRepository,
			IApiTeacherRequestModelValidator teacherModelValidator,
			IBOLTeacherMapper BOLteacherMapper,
			IDALTeacherMapper DALteacherMapper)
			: base(logger, teacherRepository,
			       teacherModelValidator,
			       BOLteacherMapper,
			       DALteacherMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>2c05dd62f8456911e8b4045db137a7cf</Hash>
</Codenesium>*/