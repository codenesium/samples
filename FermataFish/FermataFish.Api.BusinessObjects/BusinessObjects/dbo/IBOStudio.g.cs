using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOStudio
	{
		Task<CreateResponse<int>> Create(
			StudioModel model);

		Task<ActionResponse> Update(int id,
		                            StudioModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOStudio GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFStudio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStudio> GetWhereDirect(Expression<Func<EFStudio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e153b0b9536de2c3f2bb89e046c20ed3</Hash>
</Codenesium>*/