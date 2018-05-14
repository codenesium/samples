using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkStatusRepository
	{
		POCOLinkStatus Create(ApiLinkStatusModel model);

		void Update(int id,
		            ApiLinkStatusModel model);

		void Delete(int id);

		POCOLinkStatus Get(int id);

		List<POCOLinkStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOLinkStatus Name(string name);
	}
}

/*<Codenesium>
    <Hash>8a2ada7bcb8ccb992bb9c446ba7865d7</Hash>
</Codenesium>*/