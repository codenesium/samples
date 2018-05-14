using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudentRepository
	{
		POCOStudent Create(StudentModel model);

		void Update(int id,
		            StudentModel model);

		void Delete(int id);

		POCOStudent Get(int id);

		List<POCOStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b22dea697f97d6f1079e5006cfde23d8</Hash>
</Codenesium>*/