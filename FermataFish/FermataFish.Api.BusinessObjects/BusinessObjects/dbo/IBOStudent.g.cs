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

		POCOStudent Get(int id);

		List<POCOStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>77fb4486f3c4e3468e1a1a3f60d57d83</Hash>
</Codenesium>*/