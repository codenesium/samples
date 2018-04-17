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
			IStudentXFamilyModelValidator studentXFamilyModelValidator)
			: base(logger, studentXFamilyRepository, studentXFamilyModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>cc8b5e8db4d727b6cda1acf4d1187416</Hash>
</Codenesium>*/