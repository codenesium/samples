using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRefTeamRepository
	{
		POCOMachineRefTeam Create(ApiMachineRefTeamModel model);

		void Update(int id,
		            ApiMachineRefTeamModel model);

		void Delete(int id);

		POCOMachineRefTeam Get(int id);

		List<POCOMachineRefTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>590f139c089bdefedfee14eebe8e4881</Hash>
</Codenesium>*/