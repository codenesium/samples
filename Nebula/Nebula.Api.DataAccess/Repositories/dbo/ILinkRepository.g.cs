using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkRepository
	{
		POCOLink Create(LinkModel model);

		void Update(int id,
		            LinkModel model);

		void Delete(int id);

		POCOLink Get(int id);

		List<POCOLink> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLink> ChainId(int chainId);
		POCOLink ExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>27f11ff55bb48a3cc765e32384b10777</Hash>
</Codenesium>*/