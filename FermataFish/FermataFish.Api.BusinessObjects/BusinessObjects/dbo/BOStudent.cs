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
			IApiStudentRequestModelValidator studentModelValidator,
			IBOLStudentMapper studentMapper)
			: base(logger, studentRepository, studentModelValidator, studentMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>ff6b52a60555b243e90ff4f5150d76f5</Hash>
</Codenesium>*/