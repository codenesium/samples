using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainRepository
	{
		int Create(ChainModel model);

		void Update(int id,
		            ChainModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOChain GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFChain, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOChain> GetWhereDirect(Expression<Func<EFChain, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c49754dc23b3ee2c4c1d6f2a351a415f</Hash>
</Codenesium>*/