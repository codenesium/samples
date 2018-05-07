using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRefTeamRepository
	{
		int Create(MachineRefTeamModel model);

		void Update(int id,
		            MachineRefTeamModel model);

		void Delete(int id);

		POCOMachineRefTeam Get(int id);

		List<POCOMachineRefTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b314f7c80599bcd38c24c01573f3ea40</Hash>
</Codenesium>*/