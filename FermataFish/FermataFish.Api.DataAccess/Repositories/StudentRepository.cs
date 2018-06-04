using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class StudentRepository: AbstractStudentRepository, IStudentRepository
	{
		public StudentRepository(
			ILogger<StudentRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>932cc31e22bc9e704bd0e5a6e50ef047</Hash>
</Codenesium>*/