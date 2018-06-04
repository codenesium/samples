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
	public class StudentXFamilyService: AbstractStudentXFamilyService, IStudentXFamilyService
	{
		public StudentXFamilyService(
			ILogger<StudentXFamilyRepository> logger,
			IStudentXFamilyRepository studentXFamilyRepository,
			IApiStudentXFamilyRequestModelValidator studentXFamilyModelValidator,
			IBOLStudentXFamilyMapper BOLstudentXFamilyMapper,
			IDALStudentXFamilyMapper DALstudentXFamilyMapper)
			: base(logger, studentXFamilyRepository,
			       studentXFamilyModelValidator,
			       BOLstudentXFamilyMapper,
			       DALstudentXFamilyMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>839538959042c615205b16211b9365d4</Hash>
</Codenesium>*/