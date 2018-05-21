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
		Task<CreateResponse<POCOStudentXFamily>> Create(
			ApiStudentXFamilyModel model);

		Task<ActionResponse> Update(int id,
		                            ApiStudentXFamilyModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOStudentXFamily> Get(int id);

		Task<List<POCOStudentXFamily>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>497532b844eeb45c6a2f790d9eb9cfee</Hash>
</Codenesium>*/