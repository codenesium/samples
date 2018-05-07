using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLink
	{
		Task<CreateResponse<int>> Create(
			LinkModel model);

		Task<ActionResponse> Update(int id,
		                            LinkModel model);

		Task<ActionResponse> Delete(int id);

		POCOLink Get(int id);

		List<POCOLink> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6d3485927956a1f1568c8b9d148d3a67</Hash>
</Codenesium>*/