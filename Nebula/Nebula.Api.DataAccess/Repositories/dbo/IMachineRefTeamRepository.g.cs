using System;
using System.Linq.Expressions;
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

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<EFMachineRefTeam, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>21f5ecca0120c520ac3c965a0f4b2fba</Hash>
</Codenesium>*/