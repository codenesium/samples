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

		POCOMachine Get(int id);

		List<POCOMachine> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fd35c02a6a5cd92b9417bf3f7d22d1be</Hash>
</Codenesium>*/