using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainStatusRepository
	{
		int Create(string name);

		void Update(int id, string name);

		void Delete(int id);

		Response GetById(int id);

		POCOChainStatus GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFChainStatus, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOChainStatus> GetWhereDirect(Expression<Func<EFChainStatus, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2d835a351134181e2772e02f3f4b90c1</Hash>
</Codenesium>*/