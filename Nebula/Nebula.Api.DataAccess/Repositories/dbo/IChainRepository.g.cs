using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainRepository
	{
		POCOChain Create(ApiChainModel model);

		void Update(int id,
		            ApiChainModel model);

		void Delete(int id);

		POCOChain Get(int id);

		List<POCOChain> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOChain ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>f6721d16c591f5dbeb2c5747a1fe8c33</Hash>
</Codenesium>*/