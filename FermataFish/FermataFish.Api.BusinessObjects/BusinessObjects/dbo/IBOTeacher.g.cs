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

		Task<POCOTeacher> Get(int id);

		Task<List<POCOTeacher>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1941b518b89f97cc0b6149f9356f6a5b</Hash>
</Codenesium>*/