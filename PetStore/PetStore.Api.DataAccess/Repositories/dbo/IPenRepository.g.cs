using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPenRepository
	{
		int Create(PenModel model);

		void Update(int id,
		            PenModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOPen GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPen, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPen> GetWhereDirect(Expression<Func<EFPen, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>495e335075f5c02a9fa1e5fde6dfb203</Hash>
</Codenesium>*/