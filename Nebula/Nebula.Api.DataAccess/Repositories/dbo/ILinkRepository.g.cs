using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkRepository
	{
		POCOLink Create(ApiLinkModel model);

		void Update(int id,
		            ApiLinkModel model);

		void Delete(int id);

		POCOLink Get(int id);

		List<POCOLink> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLink> ChainId(int chainId);
		POCOLink ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>9354c51f355393a35419a51ef526aed2</Hash>
</Codenesium>*/