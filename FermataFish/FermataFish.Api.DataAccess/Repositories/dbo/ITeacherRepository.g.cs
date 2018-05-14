using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherRepository
	{
		POCOTeacher Create(TeacherModel model);

		void Update(int id,
		            TeacherModel model);

		void Delete(int id);

		POCOTeacher Get(int id);

		List<POCOTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6b94f9e5f9b491567c6ab7abea927c46</Hash>
</Codenesium>*/