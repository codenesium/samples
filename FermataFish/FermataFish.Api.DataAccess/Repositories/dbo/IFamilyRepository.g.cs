using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IFamilyRepository
	{
		int Create(FamilyModel model);

		void Update(int id,
		            FamilyModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOFamily GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOFamily> GetWhereDirect(Expression<Func<EFFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>34d8433a9fc0c1193db8b9e050925da4</Hash>
</Codenesium>*/