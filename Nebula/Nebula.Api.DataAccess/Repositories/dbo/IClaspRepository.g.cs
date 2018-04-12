using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IClaspRepository
	{
		int Create(
			int previousChainId,
			int nextChainId);

		void Update(int id,
		            int previousChainId,
		            int nextChainId);

		void Delete(int id);

		Response GetById(int id);

		POCOClasp GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFClasp, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOClasp> GetWhereDirect(Expression<Func<EFClasp, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9d52b38029d27a8414b2feb1fb45794b</Hash>
</Codenesium>*/