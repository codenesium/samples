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
	public class BOStudent: AbstractBOStudent, IBOStudent
	{
		public BOStudent(
			ILogger<StudentRepository> logger,
			IStudentRepository studentRepository,
			IApiStudentModelValidator studentModelValidator)
			: base(logger, studentRepository, studentModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>8f7d426648885c50b727a772c4cf189b</Hash>
</Codenesium>*/