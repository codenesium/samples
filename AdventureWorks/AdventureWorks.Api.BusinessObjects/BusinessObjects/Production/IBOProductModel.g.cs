using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductModel
	{
		Task<CreateResponse<int>> Create(
			ProductModelModel model);

		Task<ActionResponse> Update(int productModelID,
		                            ProductModelModel model);

		Task<ActionResponse> Delete(int productModelID);

		ApiResponse GetById(int productModelID);

		POCOProductModel GetByIdDirect(int productModelID);

		ApiResponse GetWhere(Expression<Func<EFProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductModel> GetWhereDirect(Expression<Func<EFProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6fe02cd48419ff0841def3b00d33cc1c</Hash>
</Codenesium>*/