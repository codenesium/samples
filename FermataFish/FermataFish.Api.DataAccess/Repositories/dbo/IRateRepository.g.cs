using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IRateRepository
	{
		int Create(RateModel model);

		void Update(int id,
		            RateModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCORate GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCORate> GetWhereDirect(Expression<Func<EFRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6b81447ff9c1c3a1b5d722d1f4889bfc</Hash>
</Codenesium>*/