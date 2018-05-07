using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOTeacher
	{
		Task<CreateResponse<int>> Create(
			TeacherModel model);

		Task<ActionResponse> Update(int id,
		                            TeacherModel model);

		Task<ActionResponse> Delete(int id);

		POCOTeacher Get(int id);

		List<POCOTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9f7fbbe9ee3e6ce8a9a8532085cd8647</Hash>
</Codenesium>*/