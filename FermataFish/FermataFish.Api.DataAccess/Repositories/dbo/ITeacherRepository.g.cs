using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherRepository
	{
		int Create(
			string firstName,
			string lastName,
			string email,
			string phone,
			DateTime birthday,
			int studioId);

		void Update(int id,
		            string firstName,
		            string lastName,
		            string email,
		            string phone,
		            DateTime birthday,
		            int studioId);

		void Delete(int id);

		Response GetById(int id);

		POCOTeacher GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTeacher> GetWhereDirect(Expression<Func<EFTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0f577a0704f3106a514c3c5f178e8008</Hash>
</Codenesium>*/