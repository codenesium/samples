using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOTeam
	{
		Task<CreateResponse<int>> Create(
			TeamModel model);

		Task<ActionResponse> Update(int id,
		                            TeamModel model);

		Task<ActionResponse> Delete(int id);

		POCOTeam Get(int id);

		List<POCOTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2430e009d0b5f7dedf8743d87deec680</Hash>
</Codenesium>*/