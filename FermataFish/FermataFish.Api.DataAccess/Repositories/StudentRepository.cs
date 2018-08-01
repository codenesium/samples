using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public partial class StudentRepository : AbstractStudentRepository, IStudentRepository
	{
		public StudentRepository(
			ILogger<StudentRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>48e5ffebf51be598093c978d294fe5ed</Hash>
</Codenesium>*/