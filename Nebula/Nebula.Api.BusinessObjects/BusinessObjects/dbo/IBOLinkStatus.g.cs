using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLinkStatus
	{
		Task<CreateResponse<POCOLinkStatus>> Create(
			LinkStatusModel model);

		Task<ActionResponse> Update(int id,
		                            LinkStatusModel model);

		Task<ActionResponse> Delete(int id);

		POCOLinkStatus Get(int id);

		List<POCOLinkStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOLinkStatus Name(string name);
	}
}

/*<Codenesium>
    <Hash>2847186a747f4b604da8dbe4de97c3af</Hash>
</Codenesium>*/