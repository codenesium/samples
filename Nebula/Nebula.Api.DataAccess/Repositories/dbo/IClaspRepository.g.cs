using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IClaspRepository
	{
		int Create(ClaspModel model);

		void Update(int id,
		            ClaspModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOClasp GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFClasp, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOClasp> GetWhereDirect(Expression<Func<EFClasp, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d352f23a4160928e2e1364fb7fedb42a</Hash>
</Codenesium>*/