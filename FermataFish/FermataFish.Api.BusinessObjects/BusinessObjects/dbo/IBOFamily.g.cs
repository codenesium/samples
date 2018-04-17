using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOFamily
	{
		Task<CreateResponse<int>> Create(
			FamilyModel model);

		Task<ActionResponse> Update(int id,
		                            FamilyModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOFamily GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOFamily> GetWhereDirect(Expression<Func<EFFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d0a89463bddb80192d5a69b6175cde53</Hash>
</Codenesium>*/