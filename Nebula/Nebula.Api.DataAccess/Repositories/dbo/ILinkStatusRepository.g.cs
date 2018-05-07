using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkStatusRepository
	{
		int Create(LinkStatusModel model);

		void Update(int id,
		            LinkStatusModel model);

		void Delete(int id);

		POCOLinkStatus Get(int id);

		List<POCOLinkStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>894e2bef8ac5aa114381322bf662de22</Hash>
</Codenesium>*/