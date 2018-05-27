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
	public class StudentRepository: AbstractStudentRepository, IStudentRepository
	{
		public StudentRepository(
			IDALStudentMapper mapper,
			ILogger<StudentRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>fd4c5189fd7f250f99739534cd877e41</Hash>
</Codenesium>*/