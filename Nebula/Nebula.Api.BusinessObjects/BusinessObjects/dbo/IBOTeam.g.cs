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
		Task<CreateResponse<POCOTeam>> Create(
			ApiTeamModel model);

		Task<ActionResponse> Update(int id,
		                            ApiTeamModel model);

		Task<ActionResponse> Delete(int id);

		POCOTeam Get(int id);

		List<POCOTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOTeam Name(string name);
	}
}

/*<Codenesium>
    <Hash>8cca9d313275fc7ffc4d220fd80ed86c</Hash>
</Codenesium>*/