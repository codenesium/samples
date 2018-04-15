using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudentRepository
	{
		int Create(StudentModel model);

		void Update(int id,
		            StudentModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOStudent GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStudent> GetWhereDirect(Expression<Func<EFStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b74bd5cf3869b40485662e8de1b2feb9</Hash>
</Codenesium>*/