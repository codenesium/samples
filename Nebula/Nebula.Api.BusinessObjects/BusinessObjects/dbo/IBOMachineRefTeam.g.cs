using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOMachineRefTeam
	{
		Task<CreateResponse<int>> Create(
			MachineRefTeamModel model);

		Task<ActionResponse> Update(int id,
		                            MachineRefTeamModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOMachineRefTeam GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFMachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOMachineRefTeam> GetWhereDirect(Expression<Func<EFMachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ed97950a0f45b5d160d8a490a6f4cd91</Hash>
</Codenesium>*/