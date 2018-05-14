using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainRepository
	{
		POCOChain Create(ChainModel model);

		void Update(int id,
		            ChainModel model);

		void Delete(int id);

		POCOChain Get(int id);

		List<POCOChain> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOChain ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>636638d23d5db5959798f528dee70a19</Hash>
</Codenesium>*/