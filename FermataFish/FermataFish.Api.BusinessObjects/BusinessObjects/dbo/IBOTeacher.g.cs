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
		Task<CreateResponse<POCOTeacher>> Create(
			TeacherModel model);

		Task<ActionResponse> Update(int id,
		                            TeacherModel model);

		Task<ActionResponse> Delete(int id);

		POCOTeacher Get(int id);

		List<POCOTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9d93e8d3bfba7f3a9d00615e3c865034</Hash>
</Codenesium>*/