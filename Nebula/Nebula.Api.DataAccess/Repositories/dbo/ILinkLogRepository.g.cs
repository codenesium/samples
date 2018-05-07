using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkLogRepository
	{
		int Create(LinkLogModel model);

		void Update(int id,
		            LinkLogModel model);

		void Delete(int id);

		POCOLinkLog Get(int id);

		List<POCOLinkLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4edf5165e373f0263b97c818fb84fb05</Hash>
</Codenesium>*/