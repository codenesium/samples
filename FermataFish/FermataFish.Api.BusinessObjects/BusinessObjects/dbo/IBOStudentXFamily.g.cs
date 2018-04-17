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

		ApiResponse GetById(int id);

		POCOStudentXFamily GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFStudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStudentXFamily> GetWhereDirect(Expression<Func<EFStudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a3dd85751ad97daf42f87b5c4bbfe355</Hash>
</Codenesium>*/