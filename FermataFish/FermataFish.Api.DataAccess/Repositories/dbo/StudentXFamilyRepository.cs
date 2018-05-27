using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public class StudentXFamilyRepository: AbstractStudentXFamilyRepository, IStudentXFamilyRepository
	{
		public StudentXFamilyRepository(
			IDALStudentXFamilyMapper mapper,
			ILogger<StudentXFamilyRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>ac5aac96431784958106ef911e3fb9fc</Hash>
</Codenesium>*/