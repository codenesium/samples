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

		POCOStudentXFamily Get(int id);

		List<POCOStudentXFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c50ee93e37b573dacc0ce56ea14d158b</Hash>
</Codenesium>*/