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

		ApiResponse GetById(int id);

		POCOMachineRefTeam GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFMachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOMachineRefTeam> GetWhereDirect(Expression<Func<EFMachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>efaeb024873765845c9750d16a2accc8</Hash>
</Codenesium>*/