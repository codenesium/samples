using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudentXFamilyRepository
	{
		int Create(StudentXFamilyModel model);

		void Update(int id,
		            StudentXFamilyModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOStudentXFamily GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFStudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStudentXFamily> GetWhereDirect(Expression<Func<EFStudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6cecd0d93f90763990a6c79f13db97fc</Hash>
</Codenesium>*/