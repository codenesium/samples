using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkRepository
	{
		int Create(LinkModel model);

		void Update(int id,
		            LinkModel model);

		void Delete(int id);

		POCOLink Get(int id);

		List<POCOLink> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>41557ee1ecd7fb55046afba494579d53</Hash>
</Codenesium>*/