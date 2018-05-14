using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherRepository
	{
		POCOTeacher Create(ApiTeacherModel model);

		void Update(int id,
		            ApiTeacherModel model);

		void Delete(int id);

		POCOTeacher Get(int id);

		List<POCOTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>80fc85496ec67cc333546f70015b354b</Hash>
</Codenesium>*/