using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOStudentXFamily
	{
		Task<CreateResponse<int>> Create(
			StudentXFamilyModel model);

		Task<ActionResponse> Update(int id,
		                            StudentXFamilyModel model);

		Task<ActionResponse> Delete(int id);

		POCOStudentXFamily Get(int id);

		List<POCOStudentXFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>948e34d524c6cd0e639071a024d9204f</Hash>
</Codenesium>*/