using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRefTeamRepository
	{
		int Create(int machineId,
		           int teamId);

		void Update(int id, int machineId,
		            int teamId);

		void Delete(int id);

		Response GetById(int id);

		POCOMachineRefTeam GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFMachineRefTeam, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOMachineRefTeam> GetWhereDirect(Expression<Func<EFMachineRefTeam, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>77c23e033dde699e7703d46f15462a66</Hash>
</Codenesium>*/