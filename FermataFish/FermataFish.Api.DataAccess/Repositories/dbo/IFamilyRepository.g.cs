using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IFamilyRepository
	{
		int Create(
			string pcFirstName,
			string pcLastName,
			string pcPhone,
			string pcEmail,
			string notes,
			int studioId);

		void Update(int id,
		            string pcFirstName,
		            string pcLastName,
		            string pcPhone,
		            string pcEmail,
		            string notes,
		            int studioId);

		void Delete(int id);

		Response GetById(int id);

		POCOFamily GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOFamily> GetWhereDirect(Expression<Func<EFFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8c46c9dad6f5478fda2514244725a1da</Hash>
</Codenesium>*/