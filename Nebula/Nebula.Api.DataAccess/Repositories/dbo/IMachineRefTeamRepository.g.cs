using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRefTeamRepository
	{
		int Create(
			int machineId,
			int teamId);

		void Update(int id,
		            int machineId,
		            int teamId);

		void Delete(int id);

		Response GetById(int id);

		POCOMachineRefTeam GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFMachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOMachineRefTeam> GetWhereDirect(Expression<Func<EFMachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3974a9fce10c06cd9c83610f7d75d519</Hash>
</Codenesium>*/