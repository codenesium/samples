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
			ApiStudentModel model);

		Task<ActionResponse> Update(int id,
		                            ApiStudentModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOStudent> Get(int id);

		Task<List<POCOStudent>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f18cca0fcaa92dc33aa7c6cade68a857</Hash>
</Codenesium>*/