using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudentXFamilyRepository
	{
		POCOStudentXFamily Create(StudentXFamilyModel model);

		void Update(int id,
		            StudentXFamilyModel model);

		void Delete(int id);

		POCOStudentXFamily Get(int id);

		List<POCOStudentXFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f1a651f8410d9270117d50610cccca2e</Hash>
</Codenesium>*/