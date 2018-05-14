using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRefTeamRepository
	{
		POCOMachineRefTeam Create(MachineRefTeamModel model);

		void Update(int id,
		            MachineRefTeamModel model);

		void Delete(int id);

		POCOMachineRefTeam Get(int id);

		List<POCOMachineRefTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9ec7043a84c0df0f5142e3297c0f2069</Hash>
</Codenesium>*/