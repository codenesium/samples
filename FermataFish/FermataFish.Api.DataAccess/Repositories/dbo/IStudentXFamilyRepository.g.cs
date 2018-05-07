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

		POCOStudentXFamily Get(int id);

		List<POCOStudentXFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ef8217943ae6edce831f6d0d1c3f711f</Hash>
</Codenesium>*/