using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudentXFamilyRepository
	{
		POCOStudentXFamily Create(ApiStudentXFamilyModel model);

		void Update(int id,
		            ApiStudentXFamilyModel model);

		void Delete(int id);

		POCOStudentXFamily Get(int id);

		List<POCOStudentXFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>41d140469ad3398bde8de0e8fee4f627</Hash>
</Codenesium>*/