using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOStudent
	{
		Task<CreateResponse<POCOStudent>> Create(
			StudentModel model);

		Task<ActionResponse> Update(int id,
		                            StudentModel model);

		Task<ActionResponse> Delete(int id);

		POCOStudent Get(int id);

		List<POCOStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>daee4d0f378122b4df50ae7735e0e332</Hash>
</Codenesium>*/