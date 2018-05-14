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
			ApiTeacherModel model);

		Task<ActionResponse> Update(int id,
		                            ApiTeacherModel model);

		Task<ActionResponse> Delete(int id);

		POCOTeacher Get(int id);

		List<POCOTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>45b7708790a2c53d535f0f193bd1059d</Hash>
</Codenesium>*/