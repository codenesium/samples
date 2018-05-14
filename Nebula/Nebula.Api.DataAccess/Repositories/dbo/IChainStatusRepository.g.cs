using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainStatusRepository
	{
		POCOChainStatus Create(ChainStatusModel model);

		void Update(int id,
		            ChainStatusModel model);

		void Delete(int id);

		POCOChainStatus Get(int id);

		List<POCOChainStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOChainStatus Name(string name);
	}
}

/*<Codenesium>
    <Hash>757b5740ba47058606c815a16bfff543</Hash>
</Codenesium>*/