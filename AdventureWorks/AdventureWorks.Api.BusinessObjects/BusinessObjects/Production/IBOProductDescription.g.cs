using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductDescription
	{
		Task<CreateResponse<int>> Create(
			ProductDescriptionModel model);

		Task<ActionResponse> Update(int productDescriptionID,
		                            ProductDescriptionModel model);

		Task<ActionResponse> Delete(int productDescriptionID);

		ApiResponse GetById(int productDescriptionID);

		POCOProductDescription GetByIdDirect(int productDescriptionID);

		ApiResponse GetWhere(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductDescription> GetWhereDirect(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e6319625e03c868e11aa8b04bea7d61e</Hash>
</Codenesium>*/