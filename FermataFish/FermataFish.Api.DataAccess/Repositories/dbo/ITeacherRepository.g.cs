using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherRepository
	{
		int Create(TeacherModel model);

		void Update(int id,
		            TeacherModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOTeacher GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTeacher> GetWhereDirect(Expression<Func<EFTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ee9013842a05fc2623f855fa118bf484</Hash>
</Codenesium>*/