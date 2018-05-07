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

		POCOStudent Get(int id);

		List<POCOStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4ede732bfeded45eb8bc4bedcd7c9eaa</Hash>
</Codenesium>*/