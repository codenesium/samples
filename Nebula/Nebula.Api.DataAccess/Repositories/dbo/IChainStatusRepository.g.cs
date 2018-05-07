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

		POCOChainStatus Get(int id);

		List<POCOChainStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8fc482016381dd14d226e84fd4203485</Hash>
</Codenesium>*/