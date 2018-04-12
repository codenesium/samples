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
			ILogger<StudentXFamilyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}

		protected override List<EFStudentXFamily> SearchLinqEF(Expression<Func<EFStudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFStudentXFamily>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFStudentXFamily>();
			}
			else
			{
				return this.context.Set<EFStudentXFamily>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFStudentXFamily>();
			}
		}

		protected override List<EFStudentXFamily> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFStudentXFamily>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFStudentXFamily>();
			}
			else
			{
				return this.context.Set<EFStudentXFamily>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFStudentXFamily>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>4b4a0b8b6181873e4a63645331a26f0c</Hash>
</Codenesium>*/