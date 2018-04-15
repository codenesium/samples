using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainStatusRepository
	{
		int Create(ChainStatusModel model);

		void Update(int id,
		            ChainStatusModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOChainStatus GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOChainStatus> GetWhereDirect(Expression<Func<EFChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f6c3f3328ce33e45e6b9ae7d98d3aeb4</Hash>
</Codenesium>*/