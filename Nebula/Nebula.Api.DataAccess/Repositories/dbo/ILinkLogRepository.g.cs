using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkLogRepository
	{
		POCOLinkLog Create(LinkLogModel model);

		void Update(int id,
		            LinkLogModel model);

		void Delete(int id);

		POCOLinkLog Get(int id);

		List<POCOLinkLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2e2ccd225750d83dd103ae8562733166</Hash>
</Codenesium>*/