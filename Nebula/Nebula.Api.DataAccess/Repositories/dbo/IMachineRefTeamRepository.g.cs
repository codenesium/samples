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

		void GetWhere(Expression<Func<MachineRefTeam, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c2ff1f5819f49c288415cc354681a2dd</Hash>
</Codenesium>*/