using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IFamilyRepository
	{
		POCOFamily Create(FamilyModel model);

		void Update(int id,
		            FamilyModel model);

		void Delete(int id);

		POCOFamily Get(int id);

		List<POCOFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a55ae609ff68a688dcd5096d6b4c0e57</Hash>
</Codenesium>*/