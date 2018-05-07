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
		Task<CreateResponse<int>> Create(
			StudentModel model);

		Task<ActionResponse> Update(int id,
		                            StudentModel model);

		Task<ActionResponse> Delete(int id);

		POCOStudent Get(int id);

		List<POCOStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b6574f6668b5a1cfff02c33d814559c9</Hash>
</Codenesium>*/