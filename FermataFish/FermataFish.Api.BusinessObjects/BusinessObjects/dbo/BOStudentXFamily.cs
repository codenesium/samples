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
			IApiStudentXFamilyModelValidator studentXFamilyModelValidator)
			: base(logger, studentXFamilyRepository, studentXFamilyModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>a02daf3932c73b806740338b4f2bc82b</Hash>
</Codenesium>*/