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
	public class BOStudentXFamily: AbstractBOStudentXFamily, IBOStudentXFamily
	{
		public BOStudentXFamily(
			ILogger<StudentXFamilyRepository> logger,
			IStudentXFamilyRepository studentXFamilyRepository,
			IApiStudentXFamilyRequestModelValidator studentXFamilyModelValidator,
			IBOLStudentXFamilyMapper studentXFamilyMapper)
			: base(logger, studentXFamilyRepository, studentXFamilyModelValidator, studentXFamilyMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>daa2cbe15b956c815df3d37adde59216</Hash>
</Codenesium>*/