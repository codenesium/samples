using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOMachine
	{
		Task<CreateResponse<int>> Create(
			MachineModel model);

		Task<ActionResponse> Update(int id,
		                            MachineModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOMachine GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFMachine, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOMachine> GetWhereDirect(Expression<Func<EFMachine, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>14561f93cc937c3a6356e10645a12b60</Hash>
</Codenesium>*/