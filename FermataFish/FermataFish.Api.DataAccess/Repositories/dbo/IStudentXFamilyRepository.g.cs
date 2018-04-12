using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudentXFamilyRepository
	{
		int Create(
			int studentId,
			int familyId);

		void Update(int id,
		            int studentId,
		            int familyId);

		void Delete(int id);

		Response GetById(int id);

		POCOStudentXFamily GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFStudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStudentXFamily> GetWhereDirect(Expression<Func<EFStudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1fdd2493d3961acc71c41ad54b1b6899</Hash>
</Codenesium>*/