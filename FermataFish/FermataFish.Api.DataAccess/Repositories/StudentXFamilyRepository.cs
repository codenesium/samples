using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class StudentXFamilyRepository: AbstractStudentXFamilyRepository, IStudentXFamilyRepository
	{
		public StudentXFamilyRepository(
			ILogger<StudentXFamilyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>5fcd0b537853e58028ad53466fba164c</Hash>
</Codenesium>*/