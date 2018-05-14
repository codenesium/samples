using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudentRepository
	{
		POCOStudent Create(ApiStudentModel model);

		void Update(int id,
		            ApiStudentModel model);

		void Delete(int id);

		POCOStudent Get(int id);

		List<POCOStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>08e6b218e7ee8a29557da0002cc68788</Hash>
</Codenesium>*/