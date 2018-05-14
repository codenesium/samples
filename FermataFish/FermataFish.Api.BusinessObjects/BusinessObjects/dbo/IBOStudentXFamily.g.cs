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
			StudentXFamilyModel model);

		Task<ActionResponse> Update(int id,
		                            StudentXFamilyModel model);

		Task<ActionResponse> Delete(int id);

		POCOStudentXFamily Get(int id);

		List<POCOStudentXFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>40730a1fe172908cb73a7550b9add198</Hash>
</Codenesium>*/