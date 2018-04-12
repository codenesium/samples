using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IAdminRepository
	{
		int Create(
			string email,
			string firstName,
			string lastName,
			string phone,
			Nullable<DateTime> birthday,
			int studioId);

		void Update(int id,
		            string email,
		            string firstName,
		            string lastName,
		            string phone,
		            Nullable<DateTime> birthday,
		            int studioId);

		void Delete(int id);

		Response GetById(int id);

		POCOAdmin GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFAdmin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAdmin> GetWhereDirect(Expression<Func<EFAdmin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9b6ff7be58f869279a08f0574659ffe0</Hash>
</Codenesium>*/