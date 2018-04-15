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
			IObjectMapper mapper,
			ILogger<StudentXFamilyRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
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
    <Hash>d59eca0116d1fc4bb51af61ebca209e0</Hash>
</Codenesium>*/