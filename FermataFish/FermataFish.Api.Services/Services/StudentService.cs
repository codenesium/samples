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
	public class StudentService: AbstractStudentService, IStudentService
	{
		public StudentService(
			ILogger<StudentRepository> logger,
			IStudentRepository studentRepository,
			IApiStudentRequestModelValidator studentModelValidator,
			IBOLStudentMapper BOLstudentMapper,
			IDALStudentMapper DALstudentMapper)
			: base(logger, studentRepository,
			       studentModelValidator,
			       BOLstudentMapper,
			       DALstudentMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>c896bfd8a37c73625348e8ccd89a74ad</Hash>
</Codenesium>*/