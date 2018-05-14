using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkLogRepository
	{
		POCOLinkLog Create(ApiLinkLogModel model);

		void Update(int id,
		            ApiLinkLogModel model);

		void Delete(int id);

		POCOLinkLog Get(int id);

		List<POCOLinkLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ae6b3e66be324c5a5d44967d83c6275e</Hash>
</Codenesium>*/